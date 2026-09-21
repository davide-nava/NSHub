using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryStandardComputing : BaseEntity
{
    public string Code { get; set; } = null!;

    public SalaryStandardComputingStandardType SalaryStandardComputingStandardType { get; set; }

    public SalaryStandardComputingVersionType SalaryStandardComputingVersionType { get; set; }

    public bool IsDisabled { get; set; }

    public bool ForceCurrentValidity { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
