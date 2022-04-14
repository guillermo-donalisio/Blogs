using Blogs.Models;
using Blogs.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    // GET list/Users
    [HttpGet]    
    [Route("list/Users")]
    public async Task<ActionResult> GetAllUser() => Ok(await _userService.GetAll());

    // GET list/UsersById
    [HttpGet]        
    [Route("list/UsersById")]
	public async Task<ActionResult> GetById(int id)
	{
		if(id == 0)
			return NotFound("Please, set an ID.");

        var user = await _userService.GetById(id);
        return user != null ? Ok(user) : NotFound("User doesn't exists");
	}

    // POST create/User
    [HttpPost]       
    [Route("create/User")]
	public async Task<ActionResult> Create(User user)
	{
		if(ModelState.IsValid)
		{
			user = await _userService.Insert(user);
			//var id = user.ID; // en mi base el id es autogenerado, esto no va.
		}
		return Ok(user);
	}


}