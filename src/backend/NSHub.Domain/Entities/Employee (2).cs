using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Employee : AuditableTenantEntity
{
    public string FirstName { get; protected set; } = string.Empty;
    public string LastName { get; protected set; } = string.Empty;
    public decimal AnnualGrossSalary { get; protected set; }
    public string TimeTrackingMode { get; protected set; } = string.Empty;
    public bool IsActive { get; protected set; }

    private readonly List<TimeEntry> _timeEntries = new();
    public virtual IReadOnlyCollection<TimeEntry> TimeEntries => _timeEntries.AsReadOnly();
    private readonly List<TimeTrackingAgreement> _timeTrackingAgreements = new();
    public virtual IReadOnlyCollection<TimeTrackingAgreement> TimeTrackingAgreements => _timeTrackingAgreements.AsReadOnly();

    protected Employee() { }

    public static Employee Create()
    {
        return new Employee();
    }
}
