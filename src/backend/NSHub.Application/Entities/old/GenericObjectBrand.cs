using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GenericObjectBrand : BaseEntity
{

    public bool CitroenService { get; set; }

    public Guid CounterpartNewSaleId { get; set; }

    public Guid CounterpartNewStockId { get; set; }

    public Guid CounterpartNewPurchaseId { get; set; }

    public Guid CounterpartBargainSaleId { get; set; }

    public Guid CounterpartBargainStockId { get; set; }

    public Guid CounterpartBargainPurchaseId { get; set; }

    public Guid CounterpartDemoSaleId { get; set; }

    public Guid CounterpartDemoStockId { get; set; }

    public Guid CounterpartDemoPurchaseId { get; set; }


    public virtual CounterpartNewSale? CounterpartNewSale { get; set; }
    public virtual CounterpartNewStock? CounterpartNewStock { get; set; }
    public virtual CounterpartNewPurchase? CounterpartNewPurchase { get; set; }
    public virtual CounterpartBargainSale? CounterpartBargainSale { get; set; }
    public virtual CounterpartBargainStock? CounterpartBargainStock { get; set; }
    public virtual CounterpartBargainPurchase? CounterpartBargainPurchase { get; set; }
    public virtual CounterpartDemoSale? CounterpartDemoSale { get; set; }
    public virtual CounterpartDemoStock? CounterpartDemoStock { get; set; }
    public virtual CounterpartDemoPurchase? CounterpartDemoPurchase { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
