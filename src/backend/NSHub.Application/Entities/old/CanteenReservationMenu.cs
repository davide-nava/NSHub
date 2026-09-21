using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CanteenReservationMenu : BaseEntity
{
    public Guid CanteenReservationId { get; set; }

    public Guid CanteenMenuId { get; set; }

    public string TicketNumber { get; set; } = null!;

    public decimal EmployeePrice { get; set; }

    public decimal CompanyPrice { get; set; }


    public virtual CanteenReservation? CanteenReservation { get; set; }
    public virtual CanteenMenu? CanteenMenu { get; set; }

}
