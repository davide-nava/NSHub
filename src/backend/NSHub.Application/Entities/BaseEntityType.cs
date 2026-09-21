// <copyright file="BaseEntityType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class BaseEntityType : BaseEntity
{
    public string Code { get; set; } = null!;

    public virtual TranslationGroup? TranslationGroupDescription { get; set; }

    public Guid TranslationGroupDescriptionId { get; set; }
}
