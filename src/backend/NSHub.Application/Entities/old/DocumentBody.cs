using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Drawing;

namespace NSHub.ApplicationCore.Entities;

public class DocumentBody : BaseEntity
{
    public Guid InputConfigurationId { get; set; }

    public Guid DocumentId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public Guid ArticleId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid JobEntryId { get; set; }

    public Guid VatId { get; set; }

    public Guid RegCategoryGroupId { get; set; }

    public int StartingPriceCalculationCost { get; set; }

    public IEnumerable<DecimalGroupList> DiscountCosts { get; set; }


    public decimal PriceVatIncludedCostCurrency { get; set; }

    public decimal PriceVatExcludedCostCurrency { get; set; }

    public decimal NetPriceVatIncludedCostCurrency { get; set; }

    public decimal NetPriceVatExcludedCostCurrency { get; set; }

    public decimal TotalPriceVatIncludedCostCurrency { get; set; }

    public decimal TotalPriceVatExcludedCostCurrency { get; set; }

    public int StartingPriceCalculationSale { get; set; }


    public IEnumerable<DecimalGroupList> DiscountSales { get; set; }

    public decimal PriceVatIncludedSaleCurrency { get; set; }

    public decimal PriceVatExcludedSaleCurrency { get; set; }

    public decimal NetPriceVatIncludedSaleCurrency { get; set; }

    public decimal NetPriceVatExcludedSaleCurrency { get; set; }

    public decimal TotalPriceVatIncludedSaleCurrency { get; set; }

    public decimal TotalPriceVatExcludedSaleCurrency { get; set; }

    public decimal DimensionsHeight { get; set; }

    public decimal DimensionsWidth { get; set; }

    public decimal DimensionsDepth { get; set; }

    public IEnumerable<DecimalGroupList> PackageQuantities { get; set; }

    public Guid UnitId { get; set; }

    public decimal Factor { get; set; }

    public IEnumerable<DeciamlList> UnitCoefficient { get; set; }

    public IEnumerable<DeciamlList> Quantities { get; set; }


    public decimal PriceVatIncludedCostBaseCurrency { get; set; }

    public decimal PriceVatExcludedCostBaseCurrency { get; set; }

    public decimal NetPriceVatIncludedCostBaseCurrency { get; set; }

    public decimal NetPriceVatExcludedCostBaseCurrency { get; set; }

    public decimal TotalPriceVatIncludedCostBaseCurrency { get; set; }

    public decimal TotalPriceVatExcludedCostBaseCurrency { get; set; }

    public decimal PriceVatIncludedSaleBaseCurrency { get; set; }

    public decimal PriceVatExcludedSaleBaseCurrency { get; set; }

    public decimal NetPriceVatIncludedSaleBaseCurrency { get; set; }

    public decimal NetPriceVatExcludedSaleBaseCurrency { get; set; }

    public decimal TotalPriceVatIncludedSaleBaseCurrency { get; set; }

    public decimal TotalPriceVatExcludedSaleBaseCurrency { get; set; }


    public Guid DescriptionBodyId { get; set; }

    public virtual TranslationGroup? DescriptionBody { get; set; }


    public int Index { get; set; }

    public int Level { get; set; }

    public Guid SubtotalId { get; set; }

    public Guid AgentId { get; set; }

    public decimal AgentCommissionPercentage { get; set; }

    public DateTime EditDate { get; set; }

    public int EditUser { get; set; }

    public decimal FreeAmount { get; set; }

    public bool IsNet { get; set; }

    public bool IsFontBold { get; set; }

    public bool IsFontItalic { get; set; }

    public bool IsFontUnderlined { get; set; }

    public ColorType FontColor { get; set; }

    public Guid CounterpartId { get; set; }

    public Guid DefaultArticleWarehouseId { get; set; }

    public string Code { get; set; } = null!;

    public Guid AssociationId { get; set; }

    public Guid ProcessedId { get; set; }

    public bool IsProcessed { get; set; }

    public bool ExcludeFromTurnover { get; set; }

    public Guid CostCenterId { get; set; }

    public Guid SupplierId { get; set; }

    public Guid SupplyingBodyId { get; set; }

    public string CostCurrency { get; set; } = null!;

    public bool IsNewPage { get; set; }

    public DateTime CompetenceFrom { get; set; }

    public DateTime CompetenceTo { get; set; }

    public Guid GenericObjectId { get; set; }

    public int GenericObjectMode { get; set; }

    public Guid CorrelationParentId { get; set; }

    public Guid ArticleCorrelationLinkEntryId { get; set; }

    public int Counter { get; set; }

    public int PrintDetailMode { get; set; }

    public Guid IdTechnicalReportId { get; set; }

    public int BackgroundColor { get; set; }

    public int EditEmployee { get; set; }


}
