using System;


namespace NSHub.ApplicationCore.Entities;

public class PaymentOrderSalaryIso20022 : BaseEntity
{
    public DateTime Date { get; set; }

    public string XmlData { get; set; } = null!;

    public XmlType XmlType { get; set; }

    public Guid PaymentOrderSalaryHeaderId { get; set; }

    public string PaymentOrderSalaryRowIds { get; set; } = null!;

    public string EbicsTransactionId { get; set; } = null!;

    public virtual PaymentOrderSalaryHeader? PaymentOrderSalaryHeader { get; set; }

}
