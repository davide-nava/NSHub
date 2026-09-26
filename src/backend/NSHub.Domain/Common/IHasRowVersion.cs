// <copyright file="IHasRowVersion.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// 
/// </summary>
public interface IHasRowVersion
{
    /// <summary>
    /// 
    /// </summary>
    public byte[] RowVersion { get; set; }
}
