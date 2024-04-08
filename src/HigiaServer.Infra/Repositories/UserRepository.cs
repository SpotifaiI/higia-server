using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Entities;

namespace HigiaServer.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> User = [];

    public void AddUser(User user)
    {
        User.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return User.SingleOrDefault(x => x.Email == email)!;
    }
}