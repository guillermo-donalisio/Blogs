using Blogs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blogs.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options): base(options)
    {  
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {       
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        // One-to-many relationship
        modelBuilder.Entity<Comment>()
            .HasOne<User>(u => u.User)
            .WithMany(c => c.Comments)
            .HasForeignKey(u => u.UserID);

        modelBuilder.Entity<Post>()
            .HasOne<User>(u => u.User)
            .WithMany(p => p.Posts)
            .HasForeignKey(u => u.UserID);
                     
    }

    public DbSet<User>? Users {set;get;}
    public DbSet<Post>? Posts {set;get;}
    public DbSet<Comment>? Comments {set;get;}

}