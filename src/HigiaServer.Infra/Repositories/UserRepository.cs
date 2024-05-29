using HigiaServer.Application.Repositories;
using HigiaServer.Domain.Entities;
using HigiaServer.Infra.DbContext;
using Microsoft.EntityFrameworkCore;

namespace HigiaServer.Infra.Repositories;

public class UserRepository(HigiaServerContext context) : IUserRepository
{
    private readonly HigiaServerContext _context = context;

    public async void AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email) =>
        await _context.Users.SingleOrDefaultAsync(x => x.Email == email)!;

    public async Task<User?> GetUserById(Guid userId) =>
        await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
}
