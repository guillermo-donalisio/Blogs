using Blogs.Models;
using Blogs.Repositories;

namespace Blogs.Service.Implements;

public class UserService : GenericService<User>, IUserService
{
    private IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) : base(userRepository)
    {
        this._userRepository = userRepository;
    }
}