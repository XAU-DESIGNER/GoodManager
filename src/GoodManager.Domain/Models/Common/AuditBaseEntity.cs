namespace GoodManager.Domain.Models.Common;

public abstract class AuditBaseEntity<TKey> : BaseEntity<TKey>
{
    protected AuditBaseEntity()
    {
        this.CreatedDateOnUtc = DateTime.UtcNow;
        this.UpdatedDateOnUtc = DateTime.UtcNow;
    }

    public DateTime CreatedDateOnUtc { get; set; }

    public DateTime UpdatedDateOnUtc { get; set; }

}

public abstract class AuditBaseEntity : AuditBaseEntity<int> { }