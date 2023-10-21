using HigiaServer.Domain.Common;

namespace HigiaServer.Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(string firstName, string lastName, string address, string phoneNumber, DateTime? birthday, Administrator? lastModifiedBy, 
    Administrator? createdBy) : base(firstName, lastName, address, phoneNumber, birthday, lastModifiedBy, createdBy)
    {
        IsAdmin = true;
    }
}