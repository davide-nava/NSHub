using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CanteenMenuDishType : BaseEntity
{
    public Guid CanteenMenuId { get; set; }

    public Guid DishTypeId { get; set; }

    public virtual CanteenMenu? CanteenMenu { get; set; }

    public virtual DishType? DishType { get; set; }
}
