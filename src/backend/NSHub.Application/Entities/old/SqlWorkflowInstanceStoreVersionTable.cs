using System;

namespace NSHub.ApplicationCore.Entities;

public class SqlWorkflowInstanceStoreVersionTable : BaseEntity
{
    public long? Major { get; set; }

    public long? Minor { get; set; }

    public long? Build { get; set; }

    public long? Revision { get; set; }

    public DateTime? LastUpdated { get; set; }
}
