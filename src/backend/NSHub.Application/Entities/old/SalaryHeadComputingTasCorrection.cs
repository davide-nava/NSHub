using System;
using System.Collections.Generic;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryHeadComputingTasCorrection : BaseEntity
{
    public Guid SalaryHeadCompetenceId { get; set; }

    public string TableCode { get; set; } = null!;

    public Guid SalaryHeadCorrectedId { get; set; }

    public decimal DoubleWorkRate { get; set; }

    public decimal TotalActivityRate { get; set; }

    public CorrectionType CorrectionType { get; set; }

    public virtual SalaryHeadCompetence? SalaryHeadCompetence { get; set; }
    public virtual SalaryHeadCorrected? SalaryHeadCorrected { get; set; }

}
