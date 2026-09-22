using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CartDetail : BaseEntity
{
    public Guid CartId { get; set; }

    public Guid ArticleId { get; set; }

    public decimal Quantity { get; set; }

    public IEnumerable<DecimalList> PackageQuantities { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public string Note { get; set; } = null!;

    public Guid JobEntryId { get; set; }

    public virtual JobEntry? JobEntry { get; set; }
    public virtual Article? Article { get; set; }
    public virtual Cart? Cart { get; set; }


}
