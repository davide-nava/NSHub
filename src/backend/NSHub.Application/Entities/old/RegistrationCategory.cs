using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class RegistrationCategory : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid ParentId { get; set; }

    public int Budget { get; set; }

    public int Margin { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual RegistrationCategory? RegistrationCategoryParent { get; set; }


}
