using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceSalaryExport : BaseEntity
{
    public string Code { get; set; } = null!;

    public ExportType ExportType { get; set; }

    public string OutputFile { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Layout { get; set; } = null!;

    public string ExternalDbConnection { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
