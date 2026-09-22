using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CanteenReservation : BaseEntity
{

    public Guid EmployeeId { get; set; }


    public DateTime Date { get; set; }

    public Guid CanteenMenuPlanId { get; set; }

    public string TicketNumber { get; set; } = null!;
    public virtual Employee? Employee { get; set; }
    public virtual CanteenMenuPlan? CanteenMenuPlan { get; set; }


}
