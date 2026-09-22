using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class RegistrationCategoryGroup : BaseEntity
{
    public GroupType GroupType { get; set; }

    public string UnauthorizedEmployees { get; set; } = null!;

    public ProvisionEvasionGroupType ProvisionEvasionGroupType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
