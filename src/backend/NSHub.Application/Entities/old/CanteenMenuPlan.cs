using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CanteenMenuPlan : BaseEntity
{

    public DateTime Day { get; set; }

    public Guid MealTypeId { get; set; }

    public virtual MealType? MealType { get; set; }

}
