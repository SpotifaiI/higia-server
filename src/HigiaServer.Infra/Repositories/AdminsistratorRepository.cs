using HigiaServer.Domain.Interfaces;
using HigiaServer.Infra.Data;

namespace HigiaServer.Infra.Repositories;

public class AdminsistratorRepository : IAdministratorRepository
{
    private readonly ApplicationDbContext _administratorContext;

    public AdminsistratorRepository(ApplicationDbContext administratorContext)
    {
        _administratorContext = administratorContext;
    }

    public async Task<Administrator> CreateAdministrator(Administrator administrator)
    {
        _administratorContext.Add(administrator);
        await _administratorContext.SaveChangesAsync();
        return administrator;
    }

    public async Task<Administrator> DeleteAdministrator(Guid id)
    {
        _administratorContext.Remove(await GetAdministratorById(id));
        await _administratorContext.SaveChangesAsync();

        return await GetAdministratorById(id);
    }

    public async Task<Administrator> GetAdministratorById(Guid id)
    {
        Administrator? administrator = await _administratorContext.Users
            .OfType<Administrator>().Where(x => x.Id == id).FirstOrDefaultAsync();

        return administrator!;
    }

    public async Task<List<Administrator>> GetAdministrators()
    {
        return await _administratorContext.Users
            .OfType<Administrator>().ToListAsync();
    }

    public async Task<Administrator> UpdateAdministrator(Administrator administrator)
    {
        _administratorContext.Update(administrator);
        await _administratorContext.SaveChangesAsync();
        return administrator;
    }
}