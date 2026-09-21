// <copyright file="TimesheetLine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class TimesheetLine
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? UserUpdateId { get; set; }

    public Guid? UserInsertId { get; set; }

    public DateTime DateUpdate { get; set; }

    public DateTime DateInsert { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsDeleted { get; set; }

    public byte[]? Version { get; set; }

    public bool IsActive { get; set; }

    public Guid TimesheetId { get; set; }

    public DateOnly WorkDate { get; set; }

    public decimal HoursWorked { get; set; }

    public Guid? BusinessUnitId { get; set; }

    public string? Description { get; set; }
}
