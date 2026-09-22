using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class PaymentOrderIso20022 : BaseEntity
{
    public DateTime DateAndTime { get; set; }

    public string XmlData { get; set; } = null!;

    public XmlType XmlType { get; set; }

    public Guid PaymentOrderHeaderId { get; set; }

    public string PaymentOrderRowIds { get; set; } = null!;

    public string EbicsTransactionId { get; set; } = null!;

    public virtual PaymentOrderHeader? PaymentOrderHeader { get; set; }


}
