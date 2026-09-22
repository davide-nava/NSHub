using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ActivityPlannedEwsAppointment : BaseEntity
{
    public Guid ActivityPlannedId { get; set; }

    public Guid ResourceId { get; set; }

    public Guid EmployeeId { get; set; }

    public string ExchangeAppointmentUniqueId { get; set; } = null!;

    public virtual ActivityPlanned? ActivityPlanned { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Resource? Resource { get; set; }
}
