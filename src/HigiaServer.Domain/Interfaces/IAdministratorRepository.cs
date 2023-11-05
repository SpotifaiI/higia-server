namespace HigiaServer.Domain.Interfaces;

public interface IAdministratorRepository
{
    Task<List<Administrator>> GetAdministrators();
    Task<Administrator> GetAdministratorById(Guid id);

    Task<Administrator> CreateAdministrator(Administrator administrator);
    Task<Administrator> UpdateAdministrator(Administrator administrator);
    Task<Administrator> DeleteAdministrator(Guid id);
}