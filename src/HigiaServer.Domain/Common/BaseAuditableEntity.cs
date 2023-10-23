namespace HigiaServer.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.Now;
    public DateTimeOffset LastModifiedAt { get; protected set; } = DateTimeOffset.Now;
}