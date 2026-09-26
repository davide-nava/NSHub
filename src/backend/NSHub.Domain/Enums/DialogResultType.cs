// <copyright file="DialogResultType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Possible user response results from interactive dialog prompts.
/// </summary>
public enum DialogResultType
{
    /// <summary>
    /// Discard current changes.
    /// </summary>
    Discard = -1,

    /// <summary>
    /// Negative answer.
    /// </summary>
    No = 0,

    /// <summary>
    /// Affirmative answer.
    /// </summary>
    Yes = 1,

    /// <summary>
    /// Confirm operation.
    /// </summary>
    Confirm = 2,

    /// <summary>
    /// Save changes.
    /// </summary>
    Save = 3,

    /// <summary>
    /// Cancel operation.
    /// </summary>
    Cancel = 4,

    /// <summary>
    /// Acknowledge ok.
    /// </summary>
    Ok = 5,

    /// <summary>
    /// Trigger primary modal action.
    /// </summary>
    PrimaryAction = 6,

    /// <summary>
    /// Trigger secondary modal action.
    /// </summary>
    SecondaryAction = 7,
}
