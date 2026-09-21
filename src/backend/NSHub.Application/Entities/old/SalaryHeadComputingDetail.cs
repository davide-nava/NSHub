using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryHeadComputingDetail : BaseEntity
{
    public Guid SalaryHeadComputingId { get; set; }

    public Guid SalaryComputingValidityId { get; set; }

    public decimal Base { get; set; }

    public decimal Rate { get; set; }

    public decimal Amount { get; set; }

    public Guid IterationId { get; set; }

    public string TaxAtSourceTable { get; set; } = null!;

    // TODO: Check type
    public int Category { get; set; }

    public Guid CorrectedSalaryHeadId { get; set; }

    public Guid SalaryAccountId { get; set; }


    public virtual CorrectedSalaryHead? CorrectedSalaryHead { get; set; }
    public virtual SalaryAccount? SalaryAccount { get; set; }
    public virtual Iteration? Iteration { get; set; }
    public virtual SalaryComputingValidity? SalaryComputingValidity { get; set; }

    public virtual SalaryHeadComputing? SalaryHeadComputing { get; set; }

}
