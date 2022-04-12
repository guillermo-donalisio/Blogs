namespace Blogs.Models;

public class User
{
    public int UserID {set;get;}
    public string? Name {set;get;}
    public string? Password {set;get;}
    public string? Email {set;get;}

    // Collection navigation property 
    public IList<Comment>? Comments { get; set; }
    public IList<Post>? Posts { get; set; }

}