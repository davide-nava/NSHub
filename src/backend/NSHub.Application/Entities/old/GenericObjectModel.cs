using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GenericObjectModel : BaseEntity
{

    public Guid GenericObjectBrandId { get; set; }

    public string Opb { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual GenericObjectBrand? GenericObjectBrand { get; set; }

}
