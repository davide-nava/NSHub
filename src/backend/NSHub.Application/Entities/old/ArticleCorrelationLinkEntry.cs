using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ArticleCorrelationLinkEntry : BaseEntity
{
    public Guid SourceId { get; set; }

    public Guid RelatedId { get; set; }

    public bool CreateDossierRowAutomatically { get; set; }

    public DossierRowQuantityModeType DossierRowQuantityModeType { get; set; }

    public decimal DossierRowQuantityCoefficient { get; set; }

    public Guid DossierRowQuantityFormulaId { get; set; }

    public DossierRowPriceCostModeType DossierRowPriceCostModeType { get; set; }

    public string DossierRowPriceCostArticle { get; set; } = null!;

    public decimal DossierRowPriceCostCoefficient { get; set; }

    public Guid DossierRowPriceCostFormulaId { get; set; }

    public DossierRowPriceSaleModeType DossierRowPriceSaleModeType { get; set; }

    public string DossierRowPriceSaleArticle { get; set; } = null!;

    public decimal DossierRowPriceSaleCoefficient { get; set; }

    public Guid DossierRowPriceSaleFormulaId { get; set; }

    public DocumentBodyQuantityModeType DocumentBodyQuantityModeType { get; set; }

    public decimal DocumentBodyQuantityCoefficient { get; set; }

    public Guid DocumentBodyQuantityFormulaId { get; set; }

    public DocumentBodyPriceCostModeType DocumentBodyPriceCostModeType { get; set; }

    public string DocumentBodyPriceCostArticle { get; set; } = null!;

    public decimal DocumentBodyPriceCostCoefficient { get; set; }

    public Guid DocumentBodyPriceCostFormulaId { get; set; }

    public DocumentBodyPriceSaleModeType DocumentBodyPriceSaleModeType { get; set; }

    public string DocumentBodyPriceSaleArticle { get; set; } = null!;

    public decimal DocumentBodyPriceSaleCoefficient { get; set; }

    public Guid DocumentBodyPriceSaleFormulaId { get; set; }

    public bool CreateDocumentBodyAutomatically { get; set; }

    public bool UpdateDossierRow { get; set; }

    public bool UpdateDocumentBody { get; set; }

    public int DossierRowOrder { get; set; }

    public int DocumentBodyOrder { get; set; }

    public virtual Article? Article { get; set; }
}
