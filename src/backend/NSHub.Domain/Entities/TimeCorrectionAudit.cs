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
    /// Initializes a new instance of the <see cref="TimeCorrectionAudit"/> class.
    /// Required by Entity Framework Core.
    /// </summary>
    protected TimeCorrectionAudit()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeCorrectionAudit"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the audit record.</param>
    /// <param name="timeEntryId">The identifier of the corrected time entry.</param>
    /// <param name="operatorId">The identifier of the operator performing the correction.</param>
    /// <param name="timestampUtc">The UTC timestamp when the correction was performed.</param>
    /// <param name="preClockInUtc">The clock-in timestamp prior to correction.</param>
    /// <param name="preClockOutUtc">The clock-out timestamp prior to correction.</param>
    /// <param name="preBreakMinutes">The break duration in minutes prior to correction.</param>
    /// <param name="postClockInUtc">The clock-in timestamp after correction.</param>
    /// <param name="postClockOutUtc">The clock-out timestamp after correction.</param>
    /// <param name="postBreakMinutes">The break duration in minutes after correction.</param>
    /// <param name="mandatoryReason">The mandatory reason justifying the retroactive correction.</param>
    /// <param name="ipAddress">Optional IP address of the operator.</param>
    /// <exception cref="ArgumentException">Thrown when mandatoryReason is null or whitespace.</exception>
    public TimeCorrectionAudit(
        Guid id,
        Guid timeEntryId,
        Guid operatorId,
        DateTime timestampUtc,
        DateTime preClockInUtc,
        DateTime? preClockOutUtc,
        int preBreakMinutes,
        DateTime postClockInUtc,
        DateTime? postClockOutUtc,
        int postBreakMinutes,
        string mandatoryReason,
        string? ipAddress = null)
    {
        if (string.IsNullOrWhiteSpace(mandatoryReason))
        {
            throw new ArgumentException("The correction reason is mandatory.", nameof(mandatoryReason));
        }

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        TimeEntryId = timeEntryId;
        OperatorId = operatorId;
        TimestampUtc = timestampUtc;

        PreCorrectionClockInUtc = preClockInUtc;
        PreCorrectionClockOutUtc = preClockOutUtc;
        PreCorrectionBreakMinutes = preBreakMinutes;

        PostCorrectionClockInUtc = postClockInUtc;
        PostCorrectionClockOutUtc = postClockOutUtc;
        PostCorrectionBreakMinutes = postBreakMinutes;

        MandatoryReason = mandatoryReason.Trim();
        IpAddress = ipAddress;
    }

    /// <summary>
    /// Gets the unique identifier of the associated time entry.
    /// </summary>
    public Guid TimeEntryId { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the operator who performed the correction.
    /// </summary>
    public Guid OperatorId { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the correction was recorded.
    /// </summary>
    public DateTime TimestampUtc { get; private set; }

    /// <summary>
    /// Gets the UTC clock-in timestamp prior to the correction.
    /// </summary>
    public DateTime PreCorrectionClockInUtc { get; private set; }

    /// <summary>
    /// Gets the UTC clock-out timestamp prior to the correction, if set.
    /// </summary>
    public DateTime? PreCorrectionClockOutUtc { get; private set; }

    /// <summary>
    /// Gets the break duration in minutes prior to the correction.
    /// </summary>
    public int PreCorrectionBreakMinutes { get; private set; }

    /// <summary>
    /// Gets the corrected UTC clock-in timestamp.
    /// </summary>
    public DateTime PostCorrectionClockInUtc { get; private set; }

    /// <summary>
    /// Gets the corrected UTC clock-out timestamp, if set.
    /// </summary>
    public DateTime? PostCorrectionClockOutUtc { get; private set; }

    /// <summary>
    /// Gets the corrected break duration in minutes.
    /// </summary>
    public int PostCorrectionBreakMinutes { get; private set; }

    /// <summary>
    /// Gets the mandatory statutory reason justifying the retroactive modification.
    /// </summary>
    public string MandatoryReason { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the optional IP address of the client that submitted the correction.
    /// </summary>
    public string? IpAddress { get; private set; }
}
