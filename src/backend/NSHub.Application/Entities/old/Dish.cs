using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Dish : BaseEntityType
{


    public Guid DishTypeId { get; set; }



    public virtual DishType? DishType { get; set; }

}
