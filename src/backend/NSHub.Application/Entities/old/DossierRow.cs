using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class DossierRow : BaseEntity
{

    public Guid JobEntryId { get; set; }

    public Guid ArticleId { get; set; }

    public string Remarks { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public Guid EmployeeId { get; set; }

    public decimal PriceVatIncludedCost { get; set; }

    public decimal PriceVatExcludedCost { get; set; }

    public decimal NetPriceVatIncludedCost { get; set; }

    public decimal NetPriceVatExcludedCost { get; set; }

    public decimal TotalPriceVatIncludedCost { get; set; }

    public decimal TotalPriceVatExcludedCost { get; set; }

    public IEnumerable<DecimalList> DiscountCosts { get; set; }

    public Guid VatId { get; set; }

    public int StartingPriceCalculationCost { get; set; }

    public decimal PriceVatIncludedSale { get; set; }

    public decimal PriceVatExcludedSale { get; set; }

    public decimal NetPriceVatIncludedSale { get; set; }

    public decimal NetPriceVatExcludedSale { get; set; }

    public decimal TotalPriceVatIncludedSale { get; set; }

    public decimal TotalPriceVatExcludedSale { get; set; }

    public IEnumerable<DecimalList> DiscountSales { get; set; }


    public int StartingPriceCalculationSale { get; set; }

    public decimal DimensionsHeight { get; set; }

    public decimal DimensionsWidth { get; set; }

    public decimal DimensionsDepth { get; set; }

    public IEnumerable<DecimalList> PackageQuantities { get; set; }

    public IEnumerable<GuidList> Units { get; set; }
    public IEnumerable<DecimalList> UnitCoefficients { get; set; }
    public IEnumerable<DecimalList> Quantities { get; set; }

    public Guid RegCategoryGroupId { get; set; }

    public decimal Factor { get; set; }

    public DossierRowType DossierRowType { get; set; }

    public PlanningType PlanningType { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string WeekDays { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public PeriodType PeriodType { get; set; }

    public int PeriodCycles { get; set; }

    public DateTime ReferenceDate { get; set; }

    public Guid DocumentBodyId { get; set; }

    public Guid CounterpartId { get; set; }

    public Guid DocumentId { get; set; }

    public DateTime EndPeriodicity { get; set; }

    public Guid LedgerId { get; set; }

    public Guid GeneralLedgerEntryId { get; set; }

    public Guid CostCenterId { get; set; }

    public int DayOutOfBounds { get; set; }

    public Guid CorrelationParentId { get; set; }

    public Guid ArticleCorrelationLinkEntryId { get; set; }

    public Guid ModelSourceId { get; set; }

    public DateTime EditDate { get; set; }

    public Guid EditUserId { get; set; }

    public Guid HolidayConditionId { get; set; }

    public string HolidayType { get; set; } = null!;

    public Guid EditEmployeeId { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
