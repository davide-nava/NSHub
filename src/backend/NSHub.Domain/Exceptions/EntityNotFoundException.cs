// <copyright file="EntityNotFoundException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when a requested domain entity is not found in the persistence store.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
/// </remarks>
/// <param name="entityName">The name of the missing entity.</param>
/// <param name="key">The key or identifier used to query the entity.</param>
public class EntityNotFoundException(string entityName, object key) : DomainException($"{entityName}.NotFound", $"Entity '{entityName}' with identifier '{key}' was not found.");
