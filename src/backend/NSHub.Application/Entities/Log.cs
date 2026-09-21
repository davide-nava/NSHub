// <copyright file="Log.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Log    : BaseEntity
{
    public string? MessageTemplate { get; set; }

    public string? Exception { get; set; }

    public string? Properties { get; set; }

    public string? Level { get; set; }

    public string? Message { get; set; }

    public string? Path { get; set; }

    public string? Method { get; set; }

    public string? Application { get; set; }

    public string? Email { get; set; }

    public string? CorrelationId { get; set; }

    public string? EndpointDisplayName { get; set; }

    public string? RequestIp { get; set; }

    public string? Host { get; set; }

    public string? MachineName { get; set; }

    public string? LogEvent { get; set; }

    public Guid? UserId { get; set; }

    public Guid? RecordId { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime? Date { get; set; }

    public Guid? LogTypeId { get; set; }

    public virtual LogType? LogType { get; set; }
}
