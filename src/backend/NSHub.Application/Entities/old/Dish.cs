using System;
using System.Collections.Generic;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Dish : BaseEntityType
{


    public Guid DishTypeId { get; set; }



    public virtual DishType? DishType { get; set; }

}
