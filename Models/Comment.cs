namespace Blogs.Models;

public class Comment
{
    public int CommentID {set;get;}
    public DateTime Date {set;get;}
    public string? Description {set;get;}

    // Nullable fk_user
    public int UserID {set;get;}
    public User? User {set;get;}
}