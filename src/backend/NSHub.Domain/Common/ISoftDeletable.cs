// <copyright file="ISoftDeletable.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// 
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// 
    /// </summary>
    public DateTime? DateDelete { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid? UserDeleteId { get; set; }
}
