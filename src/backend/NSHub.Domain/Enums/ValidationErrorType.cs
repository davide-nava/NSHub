// <copyright file="ValidationErrorType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

public enum ValidationErrorType
{
    FIELD_IS_REQUIRED = 1,

    FIELD_ALREADY_EXISTS = 2,

    RESOURCE_NOT_AVAILABLE = 3,

    OWNERSHIP_IS_REQUIRED = 4,

    UNDELETABLE_RECORD = 5,

    VALUE_IS_LONGER_THAN50_CHARS = 6,
}
