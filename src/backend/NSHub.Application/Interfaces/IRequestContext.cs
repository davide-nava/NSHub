// <copyright file="IRequestContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Interfaces;

/// <summary>
/// Provides ambient context information for the current HTTP or background execution request.
/// </summary>
public interface IRequestContext : Common.Interfaces.IRequestContext
{
}
