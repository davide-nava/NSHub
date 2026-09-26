// <copyright file="Employee.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing an employee.
/// </summary>
public class Employee : AuditableTenantEntity
{
    /// <summary>
    /// Gets the employee first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the employee last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the employee email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the employee OLL1 regime identifier.
    /// </summary>
    public Guid Oll1RegimeId { get; set; }

    /// <summary>
    /// Gets the employee department.
    /// </summary>
    public string Department { get; set; } = string.Empty;

    /// <summary>
    /// Gets the contractual weekly working hours.
    /// </summary>
    public decimal ContractualWeeklyHours { get; set; }

    /// <summary>
    /// Gets the annual gross salary.
    /// </summary>
    public decimal AnnualGrossSalary { get; set; }

    /// <summary>
    /// Gets the time tracking mode.
    /// </summary>
    public string TimeTrackingMode { get; set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the employee is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Gets the statutory weekly limit.
    /// </summary>
    public StatutoryWeeklyLimit StatutoryWeeklyLimit { get; set; }

    // /// <summary>
    // /// Gets the preferred language.
    // /// </summary>
    // public LanguageCode PreferredLanguage { get; set; }

    /// <summary>
    /// Gets the time entries associated with this employee.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TimeEntry> TimeEntries { get; protected set; }
        = new List<TimeEntry>();

    /// <summary>
    /// Gets the time tracking agreements associated with this employee.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TimeTrackingAgreement> TimeTrackingAgreements { get; protected set; }
        = new List<TimeTrackingAgreement>();
}
