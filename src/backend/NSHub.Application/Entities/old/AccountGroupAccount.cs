using System;

namespace NSHub.ApplicationCore.Entities;

public class AccountGroupTypeAccount : BaseEntity
{
    public Guid AccountId { get; set; }

    public Guid AccountGroupId { get; set; }

    public virtual AccountGroupType? AccountGroupType { get; set; }

    public virtual Account? Account { get; set; }
}
