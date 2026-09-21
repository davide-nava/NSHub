using System;
using System.Collections.Generic;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Article : BaseEntity
{
    public string Code { get; set; } = null!;

    public string Barcode { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public decimal Factor { get; set; }

    public decimal ProposedQuantity { get; set; }

    public Guid ImageId { get; set; }

    public Guid VatId { get; set; }

    public Guid ArticleLevelEntryId { get; set; }

    public IEnumerable<GuidList> HierarchyLevels { get; set; }

    public string Groups { get; set; } = null!;

    public Guid RegCategoryGroupId { get; set; }

    public CalculationQuantityModeType CalculationQuantityModeType { get; set; }

    public IEnumerable<DecimalList> PackageQuantities { get; set; }
    public IEnumerable<StringList> PackageQuantityLabels { get; set; }

    public IEnumerable<GuidList> Units { get; set; }

    public IEnumerable<DecimalList> Prices { get; set; }
    public IEnumerable<DecimalList> Discounts { get; set; }
    public IEnumerable<DecimalList> UnitCoefficients { get; set; }
    public IEnumerable<BoolList> WithVats { get; set; }

    public IEnumerable<DecimalList> MinimumPrices { get; set; }
    public IEnumerable<DecimalList> Numbers { get; set; }


    public IEnumerable<StringGroupList> Types { get; set; }

    public IEnumerable<BoolList> Logics { get; set; }

    public IEnumerable<TranslationGroupList> ShortTexts { get; set; }

    public Guid CounterpartId { get; set; }

    public decimal PurchasingPrice { get; set; }

    public Guid PurchasingCounterpartId { get; set; }

    public bool IsNet { get; set; }

    public int Stock { get; set; }

    public Guid ProcessingCycleId { get; set; }

    public bool IsShowAllDossierRows { get; set; }

    public int Lot { get; set; }

    public int ProductionFormula { get; set; }

    public decimal PartQuantity { get; set; }

    public Guid ReplacingId { get; set; }

    public bool IsNotAvailable { get; set; }

    public Guid DescriptionId { get; set; }

    public bool ExcludeFromTurnover { get; set; }

    public Guid CostCenterId { get; set; }



    public IEnumerable<StringGroupList> Codes { get; set; }


    public Guid IdDiscountClassId { get; set; }

    public Guid InputConfigurationId { get; set; }

    public int Notice { get; set; }

    public string NoticeText { get; set; } = null!;

    public Guid LastSaleDocumentId { get; set; }

    public Guid LastPurchaseDocumentId { get; set; }


    public IEnumerable<DateTimeList> UpdateObjectDates { get; set; }


    public bool IsTrtravel { get; set; }

    public bool IsTrmaterial { get; set; }

    public bool IsTrtime { get; set; }

    public Guid ArticleTariffId { get; set; }

    public IEnumerable<StringGroupList> PackageCodes { get; set; }
    public IEnumerable<StringGroupList> PackageBarcodes { get; set; }

    public IEnumerable<TranslationGroupList> Texts { get; set; }


    public bool IsExcludeFromPriceRecalculation { get; set; }

    public bool IsRentable { get; set; }

    public Guid RentalArticleProcessedId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
