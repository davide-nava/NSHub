using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryTaxAtSourceHistory : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime ValidFrom { get; set; }

    public string TableCode { get; set; } = null!;

    public bool Weekly { get; set; }

    // TODO: Check type
    public int Denomination { get; set; }

    // TODO: Check type
    public int Concubinage { get; set; }

    public RateSearchModeType RateSearchModeType { get; set; }

    public decimal ManualRate { get; set; }

    public decimal DoubleWorkRate { get; set; }

    public decimal TotalActivityRate { get; set; }

    public CompensationModeType CompensationModeType { get; set; }

    public HourlyCompuntingModeType HourlyCompuntingModeType { get; set; }

    public bool IsSpecialCode { get; set; }

    public string MunicipalityId { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public string OpenCategory { get; set; } = null!;

    public decimal TeleworkPercentage { get; set; }

    public virtual Employee? Employee { get; set; }
}
