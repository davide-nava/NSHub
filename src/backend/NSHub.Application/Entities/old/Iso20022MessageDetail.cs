using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Iso20022MessageDetail : BaseEntity
{
    public Guid Iso20022MessageId { get; set; }

    public Guid PaymentOrderHeaderId { get; set; }

    public Guid PaymentOrderRowId { get; set; }

    public virtual Iso20022Message? Iso20022Message { get; set; }
    public virtual PaymentOrderHeader? PaymentOrderHeader { get; set; }
    public virtual PaymentOrderRow? PaymentOrderRow { get; set; }
}
