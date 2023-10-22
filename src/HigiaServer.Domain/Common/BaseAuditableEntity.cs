namespace HigiaServer.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;
    public Administrator? CreatedBy { get; init; }
    public DateTimeOffset LastModified { get; protected set; } = DateTimeOffset.Now;
    public Administrator? LastModifiedBy { get; protected set; }
}