// <copyright file="DialogResultType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

public enum DialogResultType
{
    DISCARD = -1,

    NO = 0,

    YES = 1,

    CONFIRM = 2,

    SAVE = 3,

    CANCEL = 4,

    OK = 5,

    PRIMARY_ACTION = 6,

    SECONDARY_ACTION = 7,
}
