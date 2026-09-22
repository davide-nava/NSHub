using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Wordprocessing;

namespace NSHub.ApplicationCore.Entities;

public class CanteenMenuPlanDetail : BaseEntity
{
    public Guid CanteenMenuPlanId { get; set; }

    public Guid DishId { get; set; }

    public bool IsUnavailable { get; set; }

    public int QuantityAvailable { get; set; }


    public virtual CanteenMenuPlan? CanteenMenuPlan { get; set; }
    public virtual Dish? Dish { get; set; }


}
