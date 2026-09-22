using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputingHtTa : BaseEntity
{
    // TODO: Check type
    public int SalaryHeadComputing { get; set; }

    public string Code { get; set; } = null!;

    public RateSearchModeType RateSearchModeType { get; set; }

    public decimal DoubleWorkRate { get; set; }

    public decimal TotalActivityRate { get; set; }

    public decimal ManualRate { get; set; }

    public bool Weekly { get; set; }

    public HourlyComputingModeType HourlyComputingModeType { get; set; }

    public bool TaxAtSourceIsDisabled { get; set; }

    public CompensationModeType CompensationModeType { get; set; }

    // TODO: Check type
    public int Denomination { get; set; }

    // TODO: Check type
    public int Concubinage { get; set; }

    public string MunicipalityId { get; set; } = null!;

    public virtual SalaryHeadComputing? SalaryHeadComputing { get; set; }
}
