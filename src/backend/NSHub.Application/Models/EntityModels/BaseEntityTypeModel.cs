// <copyright file="BaseEntityTypeModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.Models.EntityModels;

public class BaseEntityTypeModel : BaseEntityModel
{
    [Display(Name = nameof(SharedResource.Code_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Code_Display_ShortName), Description = nameof(SharedResource.Code_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Code_Display_Prompt))]
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public string Code { get; set; } = null!;


    [Display(Name = nameof(SharedResource.Description_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Description_Display_ShortName), Description = nameof(SharedResource.Description_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Description_Display_Prompt))]
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
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

