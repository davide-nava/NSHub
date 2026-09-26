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
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal ContractualWeeklyHours { get; set; }
    public decimal AnnualGrossSalary { get; set; }
    public string TimeTrackingMode { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public StatutoryWeeklyLimit StatutoryWeeklyLimit { get; set; }
    public Oll1Regime Oll1Regime { get; set; }
    public LanguageCode PreferredLanguage { get; set; }

    private readonly List<TimeEntry> _timeEntries = [];
    public virtual IReadOnlyCollection<TimeEntry> TimeEntries => _timeEntries.AsReadOnly();

    private readonly List<TimeTrackingAgreement> _timeTrackingAgreements = [];
    public virtual IReadOnlyCollection<TimeTrackingAgreement> TimeTrackingAgreements => _timeTrackingAgreements.AsReadOnly();

    public static Employee Create(
        string firstName,
        string lastName,
        string email,
        string department,
        decimal contractualWeeklyHours,
        StatutoryWeeklyLimit statutoryWeeklyLimit,
        Oll1Regime oll1Regime,
        LanguageCode preferredLanguage)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Department = department,
            ContractualWeeklyHours = contractualWeeklyHours,
            StatutoryWeeklyLimit = statutoryWeeklyLimit,
            Oll1Regime = oll1Regime,
            PreferredLanguage = preferredLanguage,
            IsActive = true,
        };
    }

    public void SetPreferredLanguage(LanguageCode language) => PreferredLanguage = language;

    public void SetContract(decimal weeklyHours, StatutoryWeeklyLimit limit)
    {
        ContractualWeeklyHours = weeklyHours;
        StatutoryWeeklyLimit = limit;
    }

    public void SetRegime(Oll1Regime regime) => Oll1Regime = regime;
}
