using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputingNetDiff : BaseEntity
{
    public Guid SalaryHeadComputingId { get; set; }

    public Guid SalaryComputingValidityId { get; set; }

    public decimal Amount { get; set; }

    public Guid IterationId { get; set; }

    public string TaxAtSourceTable { get; set; } = null!;

    public string SalaryComputingCode { get; set; } = null!;

    public virtual SalaryHeadComputing? SalaryHeadComputing { get; set; }
    public virtual SalaryComputingValidity? SalaryComputingValidity { get; set; }
    public virtual Iteration? Iteration { get; set; }
}
