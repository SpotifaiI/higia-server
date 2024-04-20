using HigiaServer.Domain.Entities;

namespace HigiaServer.Application.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email);
    User? GetUserById(Guid userId);
}
