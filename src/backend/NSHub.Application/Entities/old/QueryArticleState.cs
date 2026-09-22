using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class QueryArticleState : BaseEntity
{

    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public Guid UserId { get; set; }

    public decimal PM { get; set; }

    public decimal PMp { get; set; }

    public decimal FIfo { get; set; }

    public decimal LIfo { get; set; }

    public decimal QuantityCharge { get; set; }

    public decimal ValueCharge { get; set; }

    public decimal QuantityDischarge { get; set; }

    public decimal ValueDischarge { get; set; }

    public decimal QuantityIncoming { get; set; }

    public decimal ValueIncoming { get; set; }

    public decimal QuantityOutgoing { get; set; }

    public decimal ValueOutgoing { get; set; }

    public decimal QuantityCorrection { get; set; }

    public decimal ValueCorrection { get; set; }

    public decimal InitialStock { get; set; }

    public decimal Stock { get; set; }

    public decimal Availability { get; set; }

    public decimal LastPrice { get; set; }

    public decimal CalculatedAvailability { get; set; }

    public decimal RealStock { get; set; }

    public Guid ArticleLotId { get; set; }

    public decimal QuantityPending { get; set; }

    public decimal ValuePending { get; set; }

    public decimal MinimumStock { get; set; }

    public virtual Article? Article { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
    public virtual User? User { get; set; }
    public virtual ArticleLot? ArticleLot { get; set; }

}
