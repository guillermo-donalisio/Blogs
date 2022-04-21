using Microsoft.AspNetCore.Identity;

namespace Blogs.Models;

public class UserLogin : IdentityUser
{
    public bool isActive {set;get;}
}