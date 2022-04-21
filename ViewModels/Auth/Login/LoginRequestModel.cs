using System.ComponentModel.DataAnnotations;

namespace Blogs.ViewModels.Auth.Login;
public class LoginRequestModel
{
	[Required]
	[MinLength(6)]
	public string Username {set;get;}
    
	[Required]
	[MinLength(6)]
	public string Password {set;get;}

	// public LoginRequestModel(string u, string p)
	// {
	// 	this.Username = u;
	// 	this.Password = p;
	// }
}