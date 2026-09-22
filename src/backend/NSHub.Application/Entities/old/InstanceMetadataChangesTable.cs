using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class InstanceMetadataChangesTable : BaseEntity
{
    public long SurrogateInstanceId { get; set; }

    public long ChangeTime { get; set; }

    public byte EncodingOption { get; set; }

    public byte[] Change { get; set; } = null!;
}
