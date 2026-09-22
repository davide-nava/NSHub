using System;

namespace NSHub.ApplicationCore.Entities;

public class WorkflowLayoutField : BaseEntity
{
    public Guid WorkflowLayoutId { get; set; }

    public string Name { get; set; } = null!;

    public string Fields { get; set; } = null!;

    public Guid WorkflowLayoutFieldDataTypeId { get; set; }

    public virtual WorkflowLayoutFieldDataType? WorkflowLayoutFieldDataType { get; set; }

    public string Format { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual Translation? Description { get; set; }

    public Guid FieldTranscodeId { get; set; }

    public virtual WorkflowLayout? WorkflowLayout { get; set; }

    public virtual FieldTranscode? FieldTranscode { get; set; }
}
