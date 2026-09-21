using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class InstancesTable : BaseEntity
{
    public Guid SurrogateInstanceId { get; set; }

    public Guid? SurrogateLockOwnerId { get; set; }

    public byte[]? PrimitiveDataProperties { get; set; }

    public byte[]? ComplexDataProperties { get; set; }

    public byte[]? WriteOnlyPrimitiveDataProperties { get; set; }

    public byte[]? WriteOnlyComplexDataProperties { get; set; }

    public byte[]? MetadataProperties { get; set; }

    public byte? DataEncodingOption { get; set; }

    public byte? MetadataEncodingOption { get; set; }

    public DateTime? PendingTimer { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? LastUpdated { get; set; }

    public Guid? WorkflowHostType { get; set; }

    public Guid? ServiceDeploymentId { get; set; }

    public string? SuspensionExceptionName { get; set; }

    public string? SuspensionReason { get; set; }

    public string? BlockingBookmarks { get; set; }

    public string? LastMachineRunOn { get; set; }

    public string? ExecutionStatus { get; set; }

    public bool? IsInitialized { get; set; }

    public bool? IsSuspended { get; set; }

    public bool? IsReadyToRun { get; set; }

    public bool? IsCompleted { get; set; }

    public Guid SurrogateIdentityId { get; set; }
}
