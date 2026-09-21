using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CanteenReservationDetail : BaseEntity
{
    public Guid DishId { get; set; }

    public Guid CanteenReservationMenu { get; set; }

    public virtual Dish? Dish { get; set; }
    public virtual CanteenReservationMenu? CanteenReservationMenu { get; set; }

}
