// <copyright file="TranslationModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Models.EntityModels;

public class TranslationModel : AuditableTenantEntityModel
{
    public string Text { get; set; } = null!;

    public Guid TranslationGroupId
    {
        get; set;
    }

    public virtual TranslationGroupModel? TranslationGroup
    {
        get; set;
    }

    public Guid LanguageId
    {
        get; set;
    }

    public virtual LanguageModel? Language
    {
        get; set;
    }
}
