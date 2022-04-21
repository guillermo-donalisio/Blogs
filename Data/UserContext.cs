using Blogs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Data;

public class UserContext : IdentityDbContext<UserLogin>
{
    private const string Schema = "users";
    public UserContext(DbContextOptions<UserContext> options): base(options)
    {  
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {      
        base.OnModelCreating(builder);
	    builder.HasDefaultSchema(Schema);   
    }
}