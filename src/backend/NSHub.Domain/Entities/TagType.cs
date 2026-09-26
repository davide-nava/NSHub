// <copyright file="TagType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a tag.
/// </summary>
public class TagType : AuditableLookupEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether the tag is associated with the CMS.
    /// </summary>
    public bool IsCms { get; set; }
}
