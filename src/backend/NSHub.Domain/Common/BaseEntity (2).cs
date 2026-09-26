namespace NSHub.Domain.Common;

public abstract class BaseEntity<TKey>
{
    public virtual TKey Id { get; protected set; } = default!;

    protected BaseEntity() { }

    protected BaseEntity(TKey id)
    {
        Id = id;
    }
}

public abstract class BaseEntity : BaseEntity<Guid>
{
    protected BaseEntity() : base(Guid.NewGuid()) { }
    protected BaseEntity(Guid id) : base(id) { }
}
