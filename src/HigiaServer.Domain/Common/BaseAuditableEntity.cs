namespace HigiaServer.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime LastModifiedAt { get; protected set; } = DateTime.Now;
    public Administrator? CreatedBy { get; init; }
    public Administrator? LastModifiedBy { get; protected set; }
}