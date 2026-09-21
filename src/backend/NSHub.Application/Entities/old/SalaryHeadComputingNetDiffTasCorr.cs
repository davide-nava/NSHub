using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryHeadComputingNetDiffTasCorr : BaseEntity
{
    public Guid SalaryHeadComputingTasCorrectionId { get; set; }

    public Guid SalaryComputingValidityId { get; set; }

    public decimal Amount { get; set; }

    public Guid IterationId { get; set; }

    public string TaxAtSourceTable { get; set; } = null!;

    public string SalaryComputingCode { get; set; } = null!;

    public virtual SalaryHeadComputingTasCorrection? SalaryHeadComputingTasCorrection { get; set; }
    public virtual SalaryComputingValidity? SalaryComputingValidity { get; set; }
    public virtual Iteration? Iteration { get; set; }
}
