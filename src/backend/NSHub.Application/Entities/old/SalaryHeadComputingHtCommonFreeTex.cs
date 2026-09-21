using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryHeadComputingHtCommonFreeTex : BaseEntity
{
    public Guid SalaryHeadComputingHtCommonId { get; set; }

    public virtual SalaryHeadComputingHtCommon? SalaryHeadComputingHtCommon { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
