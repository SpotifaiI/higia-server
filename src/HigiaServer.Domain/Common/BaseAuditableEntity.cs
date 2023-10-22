namespace HigiaServer.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.Now;
    public Administrator? CreatedBy { get; init; }
    public DateTimeOffset LastModifiedAt { get; protected set; } = DateTimeOffset.Now;
    public Administrator? LastModifiedBy { get; protected set; }
}