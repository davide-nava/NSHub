// <copyright file="TenantModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Services;

namespace NSHub.Application.Models.EntityModels;

public class TenantModel : AuditableTenantEntityModel
{
    public string Name { get; set; } = null!;

    public DateTime? To
    {
        get; set;
    }

    public DateTime? From
    {
        get; set;
    }

    public Guid DescriptionId
    {
        get; set;
    }

    public virtual TranslationGroupModel? Description
    {
        get; set;
    }

    public string ConnectionString { get => AesService.Decrypt(field); set; } = null!;
}
