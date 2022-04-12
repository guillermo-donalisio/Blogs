namespace Blogs.Models;

public class Post
{
    public int PostID {set;get;}
    public string? Title {set;get;}
    public DateTime Date {set;get;}
    public string? Content {set;get;}

    // Nullable fk_user
    public int UserID {set;get;}
    public User? User {set;get;}
}