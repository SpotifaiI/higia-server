using HigiaServer.Domain.Interfaces;
using HigiaServer.Infra.Data;

namespace HigiaServer.Infra.Repositories;

public class CollaboratorRepository : ICollaboratorRepository
{
    private readonly ApplicationDbContext _collaboratorContext;

    public CollaboratorRepository(ApplicationDbContext collaboratorContext)
    {
        _collaboratorContext = collaboratorContext;
    }

    public async Task<Collaborator> CreateCollaborator(Collaborator collaborator)
    {
        _collaboratorContext.Add(collaborator);
        await _collaboratorContext.SaveChangesAsync();
        return collaborator;
    }

    public async Task<Collaborator> DeleteCollaborator(Guid id)
    {
        _collaboratorContext.Remove(await GetCollaboratorById(id));
        await _collaboratorContext.SaveChangesAsync();

        return await GetCollaboratorById(id);
    }

    public async Task<Collaborator> GetCollaboratorById(Guid id)
    {
        Collaborator? collaborator = await _collaboratorContext.Users
            .OfType<Collaborator>().Where(x => x.Id == id).FirstOrDefaultAsync();

        return collaborator!;
    }

    public async Task<List<Collaborator>> GetCollaborators()
    {
        return await _collaboratorContext.Users
            .OfType<Collaborator>().ToListAsync();
    }

    public async Task<Collaborator> UpdateCollaborator(Collaborator collaborator)
    {
        _collaboratorContext.Update(collaborator);
        await _collaboratorContext.SaveChangesAsync();
        return collaborator;
    }

    public async Task<Collaborator> AddTask(Guid id, Task task)
    {
        Collaborator collaborator = await GetCollaboratorById(id);
        collaborator.Tasks.Add(task);
        await _collaboratorContext.SaveChangesAsync();

        return collaborator;
    }
}