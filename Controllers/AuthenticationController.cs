using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blogs.Models;
using Blogs.ViewModels.Auth.Login;
using Blogs.ViewModels.Auth.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Blogs.Controllers;

[ApiController]
public class AuthenticationController : Controller
{
    private readonly UserManager<UserLogin> _userManager;
    private readonly SignInManager<UserLogin> _signInManager;
    public AuthenticationController(UserManager<UserLogin> userManager, SignInManager<UserLogin> signInManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
    }

	// Register
    [HttpPost]
    [Route("Register")]    
	public async Task<IActionResult> Register(RegisterRequestModel model)
	{        
        var userExist = await _userManager.FindByNameAsync(model.Username);

        if(userExist != null)
		{
			return StatusCode(StatusCodes.Status400BadRequest);
		}

        var user = new UserLogin
		{
			UserName = model.Username,
			Email = model.Email,
            isActive = true
		};

        var result = await _userManager.CreateAsync(user, model.Password);

		if (!result.Succeeded)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, new
				{
					Status = "Error",
					Message = $"User Creation Failed! Errors: {string.Join(", ", result.Errors.Select(x => x.Description))}"
				});
		}

		return Ok(new 
		{
			Status = "Success",
			Message = "User Creation Successfully!"
		});
    }

    // Register
    [HttpPost]
    [Route("Login")]    
	public async Task<IActionResult> Login(LoginRequestModel model)
	{ 
		var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

		if (result.Succeeded)
		{
			var currentUser = await _userManager.FindByNameAsync(model.Username);

			if (currentUser.isActive)
			{
				// Generar nuestro Token
				// Devolver el token creado
                return Ok(await GetToken(currentUser));

			}
		}
		
		return StatusCode(StatusCodes.Status401Unauthorized, new
			{
				Status = "Error",
				Message = $"El usuario {model.Username} no esta autorizado!"
			});
    } 

    private async Task<LoginResponseViewModel> GetToken(UserLogin currentUser)
	{
		try
		{
			var userRoles = await _userManager.GetRolesAsync(currentUser);

			var authClaims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, currentUser.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			
			authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

			var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTRefreshTokenHIGHsecuredPasswordVVVp1OH7Xzyr"));
			
			var token = new JwtSecurityToken
			(
				issuer: "https://localhost:7158",
				audience: "https://localhost:7158",
				expires: DateTime.Now.AddHours(1),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
			);

			return new LoginResponseViewModel
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				ValidTo = token.ValidTo
			};
			
		}
		catch (System.Exception ex)
		{
			throw new Exception(ex.Message);			
		}
	} 



}