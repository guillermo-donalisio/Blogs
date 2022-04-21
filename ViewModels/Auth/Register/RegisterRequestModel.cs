using System.ComponentModel.DataAnnotations;

namespace Blogs.ViewModels.Auth.Register;

public class RegisterRequestModel
{
	[Required]
	[MinLength(6)]
    public string Username {set;get;}

	[Required]
	[EmailAddress]
	public string Email {set;get;}

	[Required]
	[MinLength(6)]
	public string Password {set;get;}
}