using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputingTasCorrectionDetail : BaseEntity
{
    public Guid SalaryComputingValidityId { get; set; }

    public Guid SalaryHeadTasCorrectionId { get; set; }

    public decimal ComputedValue { get; set; }

    public Guid IterationId { get; set; }

    public string TaxAtSourceTable { get; set; } = null!;

    // TODO: Check type
    public int Sign { get; set; }

    public string SalaryComputingCode { get; set; } = null!;

    public virtual SalaryComputingValidity? SalaryComputingValidity { get; set; }
    public virtual SalaryHeadTasCorrection? SalaryHeadTasCorrection { get; set; }
    public virtual Iteration? Iteration { get; set; }

}
