using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class LockOwnersTable : BaseEntity
{
    public Guid SurrogateLockOwnerId { get; set; }

    public DateTime LockExpiration { get; set; }

    public Guid? WorkflowHostTypeId { get; set; }

    public string MachineName { get; set; } = null!;

    public bool EnqueueCommand { get; set; }

    public bool DeletesInstanceOnCompletion { get; set; }

    public byte[]? PrimitiveLockOwnerData { get; set; }

    public byte[]? ComplexLockOwnerData { get; set; }

    public byte[]? WriteOnlyPrimitiveLockOwnerData { get; set; }

    public byte[]? WriteOnlyComplexLockOwnerData { get; set; }

    public byte? EncodingOption { get; set; }

    public byte WorkflowIdentityFilter { get; set; }

    public virtual WorkflowHostType? WorkflowHostType { get; set; }

}
