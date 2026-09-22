using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Instance : BaseEntity
{
    public DateTime? PendingTimer { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? LastUpdatedTime { get; set; }

    public Guid? ServiceDeploymentId { get; set; }

    public string? SuspensionExceptionName { get; set; }

    public string? SuspensionReason { get; set; }

    public string? ActiveBookmarks { get; set; }

    public string? CurrentMachine { get; set; }

    public string? LastMachine { get; set; }

    public string? ExecutionStatus { get; set; }

    public bool? IsInitialized { get; set; }

    public bool? IsSuspended { get; set; }

    public bool? IsCompleted { get; set; }

    public byte? EncodingOption { get; set; }

    public byte[]? ReadWritePrimitiveDataProperties { get; set; }

    public byte[]? WriteOnlyPrimitiveDataProperties { get; set; }

    public byte[]? ReadWriteComplexDataProperties { get; set; }

    public byte[]? WriteOnlyComplexDataProperties { get; set; }

    public string? IdentityName { get; set; }

    public string? IdentityPackage { get; set; }

    public long? Build { get; set; }

    public long? Major { get; set; }

    public long? Minor { get; set; }
}
