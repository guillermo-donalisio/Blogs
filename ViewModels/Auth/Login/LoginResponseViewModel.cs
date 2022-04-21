namespace Blogs.ViewModels.Auth.Login;

public class LoginResponseViewModel
{
	public string Token {set;get;}
	public DateTime ValidTo {set;get;}

    // public LoginResponseViewModel(string Token, DateTime ValidTo)
    // {
    //     this.Token = Token;
    //     this.ValidTo = ValidTo;        
    // }
}