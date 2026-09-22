using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Iso20022SalaryMessageDetail : BaseEntity
{
    public Guid Iso20022SalaryMessageId { get; set; }

    public Guid PaymentOrderSalaryHeaderId { get; set; }

    public Guid PaymentOrderSalaryRowId { get; set; }

    public virtual Iso20022SalaryMessage? Iso20022SalaryMessage { get; set; }
    public virtual PaymentOrderSalaryHeader? PaymentOrderSalaryHeader { get; set; }
    public virtual PaymentOrderSalaryRow? PaymentOrderSalaryRow { get; set; }
}
