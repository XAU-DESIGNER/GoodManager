namespace GoodManager.Domain.Models.Common;

public abstract class BaseEntity<TKey>
{
    public TKey? Id { get; set; }
    public bool IsDeleted { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>;