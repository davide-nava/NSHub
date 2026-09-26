using System;

namespace NSHub.Domain.Common;

public abstract class AuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity, ISoftDeletable, IHasRowVersion
{
    public DateTime DateInsert { get; set; }
    public DateTime? DateDelete { get; set; }
    public DateTime DateUpdate { get; set; }
    public Guid? UserInsertId { get; set; }
    public Guid? UserDeleteId { get; set; }
    public Guid? UserUpdateId { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    protected AuditableEntity() { }
    protected AuditableEntity(TKey id) : base(id) { }
}

public abstract class AuditableEntity : AuditableEntity<Guid>
{
    protected AuditableEntity() : base(Guid.NewGuid()) { }
    protected AuditableEntity(Guid id) : base(id) { }
}
