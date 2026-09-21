// <copyright file="StringListJsonModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.EntityModels.JsonModels;

public class StringListJsonModel
{
    [Display(Name = nameof(SharedResource.Index_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Index_Display_ShortName), Description = nameof(SharedResource.Index_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Index_Display_Prompt))]
    public int Index { get; set; }

    [Display(Name = nameof(SharedResource.Value_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Value_Display_ShortName), Description = nameof(SharedResource.Value_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Value_Display_Prompt))]
    public string? Value { get; set; }
}

