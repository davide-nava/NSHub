using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalarySwissdecLogDetail : BaseEntity
{
    public SalarySwissdecLogDetailDetailType SalarySwissdecLogDetailDetailType { get; set; }

    public string JobKey { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public StatusType StatusType { get; set; }

}
