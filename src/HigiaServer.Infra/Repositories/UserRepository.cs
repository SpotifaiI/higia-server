using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Entities;

namespace HigiaServer.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = [];

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(x => x.Email == email)!;
    }

    public User? GetUserById(Guid userId)
    {
        return Users.SingleOrDefault(x => x.Id == userId);
    }
}