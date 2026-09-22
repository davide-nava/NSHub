using System;

namespace NSHub.ApplicationCore.Entities;

public class AbsenceRequest : BaseEntity
{
    public Guid AccountId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public Guid AbsenceRequestStatusTypeId { get; set; }

    public string Remarks { get; set; } = null!;

    public string ExchangeAppointmentUniqueId { get; set; } = null!;

    public int Quantity { get; set; }

    public bool IsDaily { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Account? Account { get; set; }

    public virtual AbsenceRequestStatusType? AbsenceRequestStatusType { get; set; }
}
