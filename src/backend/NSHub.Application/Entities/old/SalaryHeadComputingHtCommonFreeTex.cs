using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputingHtCommonFreeTex : BaseEntity
{
    public Guid SalaryHeadComputingHtCommonId { get; set; }

    public virtual SalaryHeadComputingHtCommon? SalaryHeadComputingHtCommon { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
