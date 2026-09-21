// <copyright file="BaseEntityModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.EntityModels;

public class BaseEntityModel
{
    [Display(Name = nameof(SharedResource.Id_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.Id_Display_ShortName), Description = nameof(SharedResource.Id_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.Id_Display_Prompt))]
    public Guid Id { get; set; }

    [Display(Name = nameof(SharedResource.UserUpdateId_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.UserUpdateId_Display_ShortName), Description = nameof(SharedResource.UserUpdateId_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.UserUpdateId_Display_Prompt))]
    public Guid? UserUpdateId { get; set; }

    [Display(Name = nameof(SharedResource.UserInsertId_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.UserInsertId_Display_ShortName), Description = nameof(SharedResource.UserInsertId_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.UserInsertId_Display_Prompt))]
    public Guid? UserInsertId { get; set; }

    [Display(Name = nameof(SharedResource.DatetUpdate_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.DatetUpdate_Display_ShortName), Description = nameof(SharedResource.DatetUpdate_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.DatetUpdate_Display_Prompt))]
    public DateTime? DatetUpdate { get; set; } = DateTime.Now;

    [Display(Name = nameof(SharedResource.DateInsert_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.DateInsert_Display_ShortName), Description = nameof(SharedResource.DateInsert_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.DateInsert_Display_Prompt))]
    public DateTime? DateInsert { get; set; } = DateTime.Now;

    [Display(Name = nameof(SharedResource.TenantId_Display_Name), ResourceType = typeof(SharedResource), ShortName = nameof(SharedResource.TenantId_Display_ShortName), Description = nameof(SharedResource.TenantId_Display_Description), AutoGenerateFilter = true, Prompt = nameof(SharedResource.TenantId_Display_Prompt))]
    public Guid? TenantId { get; set; }

}

