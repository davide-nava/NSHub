// <copyright file="Employee.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

using NSHub.Domain.Common;
using NSHub.Domain.Enums;
using NSHub.Domain.Exceptions;
using NSHub.Domain.HR.ValueObjects;

/// <summary>
/// Aggregate root representing an employee, their contractual parameters, and statutory Swiss employment limits.
/// </summary>
public class Employee : AggregateRoot<EmployeeId>
{
    /// <summary>
    /// Gets the employee's given first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the employee's surname or family name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the corporate email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the business department or operational unit.
    /// </summary>
    public string Department { get; set; } = string.Empty;

    /// <summary>
    /// Gets the contractual weekly working hours.
    /// </summary>
    public decimal ContractualWeeklyHours { get; set; }

    /// <summary>
    /// Gets the statutory weekly working hour ceiling under Swiss labor law.
    /// </summary>
    public StatutoryWeeklyLimit StatutoryWeeklyLimit { get; set; }

    /// <summary>
    /// Gets the applicable OLL 1 working time regulation regime.
    /// </summary>
    public Oll1Regime Oll1Regime { get; set; }

    /// <summary>
    /// Gets the preferred language for UI and notifications.
    /// </summary>
    public LanguageCode PreferredLanguage { get; set; }

    /// <summary>
    /// Gets a value indicating whether the employee is currently active in the organization.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> class.
    /// Required by Entity Framework Core.
    /// </summary>
    protected Employee()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> aggregate root with a Guid identifier.
    /// </summary>
    public Employee(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string department,
        decimal contractualWeeklyHours,
        StatutoryWeeklyLimit statutoryWeeklyLimit,
        Oll1Regime oll1Regime,
        LanguageCode preferredLanguage)
        : this(
            new EmployeeId(id),
            firstName,
            lastName,
            email,
            department,
            contractualWeeklyHours,
            statutoryWeeklyLimit,
            oll1Regime,
            preferredLanguage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> aggregate root.
    /// </summary>
    /// <param name="id">The employee identifier.</param>
    /// <param name="firstName">The given first name.</param>
    /// <param name="lastName">The family surname.</param>
    /// <param name="email">The corporate email address.</param>
    /// <param name="department">The organizational department.</param>
    /// <param name="contractualWeeklyHours">Agreed weekly working hours.</param>
    /// <param name="statutoryWeeklyLimit">Statutory weekly hours limit.</param>
    /// <param name="oll1Regime">Applicable Swiss OLL 1 regime.</param>
    /// <param name="preferredLanguage">Preferred system language.</param>
    public Employee(
        EmployeeId id,
        string firstName,
        string lastName,
        string email,
        string department,
        decimal contractualWeeklyHours,
        StatutoryWeeklyLimit statutoryWeeklyLimit,
        Oll1Regime oll1Regime,
        LanguageCode preferredLanguage)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new BusinessRuleValidationException("Employee.FirstNameRequired", "First name is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new BusinessRuleValidationException("Employee.LastNameRequired", "Last name is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleValidationException("Employee.EmailRequired", "Email address is mandatory.");
        }

        Id = id.Value == Guid.Empty ? EmployeeId.New() : id;
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email.Trim().ToLowerInvariant();
        Department = department?.Trim() ?? string.Empty;
        ContractualWeeklyHours = contractualWeeklyHours <= 0 ? 40.0m : contractualWeeklyHours;
        StatutoryWeeklyLimit = statutoryWeeklyLimit;
        Oll1Regime = oll1Regime;
        PreferredLanguage = preferredLanguage;
        IsActive = true;
    }

    /// <summary>
    /// Updates the contractual working hours and statutory Swiss labor limits.
    /// </summary>
    /// <param name="weeklyHours">Agreed weekly hours (must be between 1 and 60).</param>
    /// <param name="limit">Statutory limit ceiling.</param>
    public void UpdateContractualTerms(decimal weeklyHours, StatutoryWeeklyLimit limit)
    {
        if (weeklyHours is <= 0 or > 60)
        {
            throw new BusinessRuleValidationException("Employee.InvalidWeeklyHours", "Contractual weekly hours must be between 1 and 60.");
        }

        ContractualWeeklyHours = weeklyHours;
        StatutoryWeeklyLimit = limit;
    }

    /// <summary>
    /// Updates the Swiss OLL 1 working time classification regime.
    /// </summary>
    /// <param name="regime">The target OLL 1 regime.</param>
    public void UpdateOll1Regime(Oll1Regime regime)
    {
        Oll1Regime = regime;
    }

    /// <summary>
    /// Sets the preferred language code for communications.
    /// </summary>
    /// <param name="language">The language code.</param>
    public void SetPreferredLanguage(LanguageCode language)
    {
        PreferredLanguage = language;
    }

    /// <summary>
    /// Deactivates the employee profile.
    /// </summary>
    public void Deactivate() => IsActive = false;

    /// <summary>
    /// Restores the employee profile to active status.
    /// </summary>
    public void Activate() => IsActive = true;
}
