using System;
using System.Collections.Generic;
using System.IO;

namespace NSHub.ApplicationCore.Entities;

public class ManualArticleHandlingHeader : BaseEntity
{

    public Guid WarehouseAccountId { get; set; }

    public DateTime HandlingDate { get; set; }

    public Guid DefaultUserWarehouseId { get; set; }

    public PriceType PriceType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual WarehouseAccount? WarehouseAccount { get; set; }
    public virtual DefaultUserWarehouse? DefaultUserWarehouse { get; set; }

}
