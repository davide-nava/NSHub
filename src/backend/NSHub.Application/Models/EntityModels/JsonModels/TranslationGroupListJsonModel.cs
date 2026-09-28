// <copyright file="TranslationGroupListJsonModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.Models.EntityModels.JsonModels;

public class TranslationGroupListJsonModel
{
    [Display(Name = nameof(SharedResource.Index_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Index_Display_ShortName), Description = nameof(SharedResource.Index_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Index_Display_Prompt))]
    public int Index
    {
        get; set;
    }

    [Display(Name = nameof(SharedResource.Description_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Description_Display_ShortName), Description = nameof(SharedResource.Description_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Description_Display_Prompt))]
    public Guid DescriptionId
    {
        get; set;
    }

    [Display(Name = nameof(SharedResource.Description_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Description_Display_ShortName), Description = nameof(SharedResource.Description_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Description_Display_Prompt))]
    public virtual TranslationGroupModel? Description
    {
        get; set;
    }
}

