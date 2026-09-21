// <copyright file="UserConfigurationJsonModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.EntityModels.JsonModels;

public class UserConfigurationJsonModel
{
    [Display(Name = nameof(SharedResource.Theme_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Theme_Display_ShortName), Description = nameof(SharedResource.Theme_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Theme_Display_Prompt))]
    public string Theme { get; set; } = "NSHubTheme";

    [Display(Name= nameof(SharedResource.Language_Display_Name), ResourceType= typeof(SharedResource), ShortName =  nameof(SharedResource.Language_Display_ShortName), Description = nameof(SharedResource.Language_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Language_Display_Prompt))]
    public string Language { get; set; } = "it-IT";

    [Display(Name = nameof(SharedResource.NumberDecimalSeparator_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.NumberDecimalSeparator_Display_ShortName), Description = nameof(SharedResource.NumberDecimalSeparator_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.NumberDecimalSeparator_Display_Prompt))]
    public string NumberDecimalSeparator { get; set; } = ".";

    [Display(Name = nameof(SharedResource.NumberGroupSeparator_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.NumberGroupSeparator_Display_ShortName), Description = nameof(SharedResource.NumberGroupSeparator_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.NumberGroupSeparator_Display_Prompt))]
    public string NumberGroupSeparator { get; set; } = ",";

    [Display(Name = nameof(SharedResource.DateTimeFormat_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.DateTimeFormat_Display_ShortName), Description = nameof(SharedResource.DateTimeFormat_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.DateTimeFormat_Display_Prompt))]
    public string? DateTimeFormat { get; set; } = "dd/MM/yyyy";
}

