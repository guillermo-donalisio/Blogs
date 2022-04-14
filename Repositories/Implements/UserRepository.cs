using Blogs.Data;
using Blogs.Models;

namespace Blogs.Repositories.Implements;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BlogContext blogContext) : base(blogContext)
    {
    }
}