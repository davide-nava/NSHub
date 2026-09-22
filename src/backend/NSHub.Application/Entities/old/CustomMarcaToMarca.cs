using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomMarcaToMarca : BaseEntity
{

    public Guid CustomMarcaToMarcaParentId { get; set; }

    public string Code { get; set; } = null!;

    public Guid DeviceTypeId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual CustomMarcaToMarca? CustomMarcaToMarcaParent { get; set; }
    public virtual DeviceType? DeviceType { get; set; }

}
