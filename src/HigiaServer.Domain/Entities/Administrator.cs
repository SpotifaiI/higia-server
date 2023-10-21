using HigiaServer.Domain.Common;

namespace HigiaServer.Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(string firstName, string lastName, string address, int number, DateTime? birthday, Administrator? lastModifiedBy, 
    Administrator? createdBy) : base(firstName, lastName, address, number, birthday, lastModifiedBy, createdBy)
    {
        IsAdmin = true;
    }
}