using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class RegistrationCategoryGroupItem : BaseEntity
{

    public Guid RegCategoryGroupId { get; set; }

    public Guid RegCategoryId { get; set; }

    // TODO: Check type
    public int Sign { get; set; }

    // TODO: Check type
    public int Billing { get; set; }

    // TODO: Check type
    public int UsePrice { get; set; }

    public virtual RegCategoryGroup? RegCategoryGroup { get; set; }
    public virtual RegCategory? RegCategory { get; set; }

}
