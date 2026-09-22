// <copyright file="TimeCorrectionAudit.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Immutable audit entity recording retroactive corrections applied to a working time entry.
/// Compliant with statutory five-year retention and traceability obligations under Swiss labor law (Art. 73 OLL 1).
/// </summary>
public class TimeCorrectionAudit : BaseEntity
{
    /// <summary>
    /// Gets the unique identifier of the associated time entry.
    /// </summary>
    public Guid TimeEntryId { get; set; }

    /// <summary>
    /// Gets the unique identifier of the operator who performed the correction.
    /// </summary>
    public Guid OperatorId { get; set; }

    /// <summary>
    /// Gets the UTC timestamp when the correction was recorded.
    /// </summary>
    public DateTime TimestampUtc { get; set; }

    /// <summary>
    /// Gets the UTC clock-in timestamp prior to the correction.
    /// </summary>
    public DateTime PreCorrectionClockInUtc { get; set; }

    /// <summary>
    /// Gets the UTC clock-out timestamp prior to the correction, if set.
    /// </summary>
    public DateTime? PreCorrectionClockOutUtc { get; set; }

    /// <summary>
    /// Gets the break duration in minutes prior to the correction.
    /// </summary>
    public int PreCorrectionBreakMinutes { get; set; }

    /// <summary>
    /// Gets the corrected UTC clock-in timestamp.
    /// </summary>
    public DateTime PostCorrectionClockInUtc { get; set; }

    /// <summary>
    /// Gets the corrected UTC clock-out timestamp, if set.
    /// </summary>
    public DateTime? PostCorrectionClockOutUtc { get; set; }

    /// <summary>
    /// Gets the corrected break duration in minutes.
    /// </summary>
    public int PostCorrectionBreakMinutes { get; set; }

    /// <summary>
    /// Gets the mandatory statutory reason justifying the retroactive modification.
    /// </summary>
    public string MandatoryReason { get; set; } = string.Empty;

    /// <summary>
    /// Gets the optional IP address of the client that submitted the correction.
    /// </summary>
    public string? IpAddress { get; set; }
}
