using HigiaServer.Domain.Common;

namespace HigiaServer.Domain.Entities;

public class Collaborators : BaseUserEntity
{
    public Collaborators(string firstName, string lastName, string address, int number, DateTime? birthday, Administrator? lastModifiedBy,
    Administrator? createdBy) : base(firstName, lastName, address, number, birthday, lastModifiedBy, createdBy)
        => IsAdmin = false;
}