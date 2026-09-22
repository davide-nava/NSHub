// <copyright file="SettingModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.NSHub.Models.EntityModels;

public class SettingModel : BaseEntityModel
{
    public string Group { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public bool IsEncrypted
    {
        get; set;
    }

    public Guid DescriptionGroupId
    {
        get; set;
    }

    public virtual TranslationGroupModel? DescriptionGroup
    {
        get; set;
    }

    public Guid DescriptionTitleId
    {
        get; set;
    }

    public virtual TranslationGroupModel? DescriptionTitle
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
}

