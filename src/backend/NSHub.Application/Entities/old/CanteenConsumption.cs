using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CanteenConsumption : BaseEntity
{
    public decimal EmployeePrice { get; set; }

    public decimal CompanyPrice { get; set; }

    public DateTime Date { get; set; }

    public Guid CanteenReservationId { get; set; }

    public virtual CanteenReservation? CanteenReservation { get; set; }
}
