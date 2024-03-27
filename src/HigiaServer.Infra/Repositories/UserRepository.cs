using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Entities;
namespace HigiaServer.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void AddUser(User user) => _users.Add(user);
    public User? GetUserByEmail(string email) => _users.SingleOrDefault(x => x.Email == email)!;

}