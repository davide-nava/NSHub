using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class PackingList : BaseEntity
{
    public Guid PackingListParentId { get; set; }

    public Guid DocumentId { get; set; }

    public Guid DocumentBodyId { get; set; }

    public Guid ArticleLotId { get; set; }

    public NodeType NodeType { get; set; }

    public string Code { get; set; }

    public decimal Quantity { get; set; }

    public IEnumerable<IntList> Integers { get; set; }

    public IEnumerable<DecimalList> Amounts { get; set; }
    public IEnumerable<DecimalList> Decimals { get; set; }
    public IEnumerable<StringList> Strings { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
