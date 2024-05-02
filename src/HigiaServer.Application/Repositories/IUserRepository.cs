using HigiaServer.Domain.Entities;

namespace HigiaServer.Application.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid userId);
    System.Threading.Tasks.Task UpdateUser(User user);
}
