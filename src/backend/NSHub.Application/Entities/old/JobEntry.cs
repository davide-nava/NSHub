using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class JobEntry : BaseEntity
{

    public int Level { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidUntil { get; set; }

    public string Code { get; set; } = null!;

    public Guid JobEntryTypeId { get; set; }

    public string CostPrice { get; set; } = null!;

    public string CostDiscount { get; set; } = null!;

    public Guid CostPriceListId { get; set; }

    public string SalePrice { get; set; } = null!;

    public string SaleDiscount { get; set; } = null!;

    public Guid SalePriceListId { get; set; }

    public Guid ArticleId { get; set; }

    public Guid RegCategoryGroupId { get; set; }

    public string CostPriceLists { get; set; } = null!;

    public string SalePriceLists { get; set; } = null!;

    public bool IgnorePriceListCorrespondentCost { get; set; }

    public bool IgnorePriceListCorrespondentSale { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int LocationTolerance { get; set; }

    public decimal Value { get; set; }

    public string Header { get; set; } = null!;

    public string Footer { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public IEnumerable<StringList> TableTexts { get; set; }

    public IEnumerable<StringList> Codes { get; set; }

    public IEnumerable<TranslationGroupList> Texts { get; set; }

    public IEnumerable<DateTimeList> Dates { get; set; }
    public IEnumerable<DecimalList> Amounts { get; set; }

    public int Percentage { get; set; }

    public bool UseEmployeeCostCost { get; set; }

    public bool UseEmployeeCostSale { get; set; }

    public int PositionOnDaily { get; set; }

    public ColorType BackColor { get; set; }

    public NumericType NumericType { get; set; }

    public int ArithmeticOperation { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
