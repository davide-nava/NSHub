// <copyright file="ValidationErrorType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Types of model validation errors.
/// </summary>
public enum ValidationErrorType
{
    /// <summary>
    /// Required field is missing.
    /// </summary>
    FieldIsRequired = 1,

    /// <summary>
    /// Unique field already exists in the system.
    /// </summary>
    FieldAlreadyExists = 2,

    /// <summary>
    /// Requested resource is not available.
    /// </summary>
    ResourceNotAvailable = 3,

    /// <summary>
    /// Ownership specification is required.
    /// </summary>
    OwnershipIsRequired = 4,

    /// <summary>
    /// The record cannot be deleted due to domain constraints.
    /// </summary>
    UndeletableRecord = 5,

    /// <summary>
    /// Value exceeds maximum 50 characters length.
    /// </summary>
    ValueIsLongerThan50Chars = 6,
}
