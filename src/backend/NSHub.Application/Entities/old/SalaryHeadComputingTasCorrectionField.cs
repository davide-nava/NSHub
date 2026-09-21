using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryHeadComputingTasCorrectionField : BaseEntity
{
    public Guid SalaryHeadTasCorrectionId { get; set; }

    public string TableCode { get; set; } = null!;

    public string FieldCode { get; set; } = null!;

    public string CorrectionValue { get; set; } = null!;

    public virtual SalaryHeadTasCorrection? SalaryHeadTasCorrection { get; set; }
}
