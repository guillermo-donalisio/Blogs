using Blogs.Models;
using Blogs.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    // GET List/Users
    [HttpGet]    
    [Route("List/Users")]
    public async Task<ActionResult> GetAllUser() => Ok(await _userService.GetAll());

    // GET List/UsersById
    [HttpGet]        
    [Route("List/UsersById")]
	public async Task<ActionResult> GetById(int id)
	{
		if(id == 0)
			return NotFound("Please, set an ID.");

        var user = await _userService.GetById(id);
        return user != null ? Ok(user) : NotFound("User doesn't exists");
	}

    // POST Create/User
    [HttpPost]       
    [Route("Create/User")]
	public async Task<ActionResult> Create(User user)
	{
		if(ModelState.IsValid)
		{
			user = await _userService.Insert(user);
		}
		return Ok(user);
	}

    // PUT Update/User
    [HttpPut]       
    [Route("Update/User")]
    public async Task<ActionResult> Edit(User user)
    {
        if(ModelState.IsValid)
		{
			user = await _userService.Update(user);
		}
		return Ok(user);
    }

    // DELETE Delete/User
    // [HttpDelete]       
    // [Route("Delete/User")]
    // public async Task<ActionResult> Delete(int? id)
    // {
    //     try
    //     {
    //         if(id == null)
    //             return NotFound();

    //         var user = await _userService.Delete(id);

    //         return Ok(user);
    //     }
    //     catch (Exception)
    //     {
    //         return NotFound("User doesn't exists");
    //     }
    // }
}