using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PriceListDetail : BaseEntity
{
    public Guid PriceListId { get; set; }

    public Guid ValidityId { get; set; }

    public Guid ArticleId { get; set; }

    public bool VatIncluded { get; set; }

    public Guid CurrencyId { get; set; }

    public int Weight { get; set; }

    public string ArticlesSelectionCondition { get; set; } = null!;

    public decimal FixedPrice { get; set; }

    public decimal FixedQuantity { get; set; }

    public IEnumerable<DecimalList> FixedDiscounts { get; set; }


    public decimal FixedNetPrice { get; set; }

    public Guid PriceFormulaId { get; set; }

    public Guid QuantityFormulaId { get; set; }

    public IEnumerable<GuidList> DiscountFormulas { get; set; }


    public Guid NetPriceFormulaId { get; set; }

    public bool IsFixedPrice { get; set; }

    public bool IsFixedQuantity { get; set; }

    public IEnumerable<BoolList> IsFixedDiscounts { get; set; }

    public bool IsFixedNetPrice { get; set; }

    public Guid DiscountClassId { get; set; }

    public bool NotAvailable { get; set; }

    public bool IsModified { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
