namespace HigiaServer.Domain.Interfaces;

public interface ICollaboratorRepository
{
    Task<List<Collaborator>> GetCollaborators();
    Task<Collaborator> GetCollaboratorById(Guid id);

    Task<Collaborator> CreateCollaborator(Collaborator collaborator);
    Task<Collaborator> UpdateCollaborator(Collaborator collaborator);
    Task<Collaborator> DeleteCollaborator(Guid id);
}
