using HigiaServer.Domain.Entities;
namespace HigiaServer.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;
    public Administrator? CreatedBy { get; init; }
    public DateTimeOffset LastModified { get; private set; } = DateTimeOffset.Now;
    public Administrator? LastModifiedBy { get; init; }
    
    protected BaseAuditableEntity(Administrator? lastModifiedBy, Administrator? createdBy)
    {
        CreatedBy = createdBy;
        LastModifiedBy = lastModifiedBy;
    }
}