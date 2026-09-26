using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TimeTrackingAgreement : AuditableTenantEntity
{
    public Guid EmployeeId { get; protected set; }
    public Guid AgreementTypeId { get; protected set; }
    public DateTime ValidFrom { get; protected set; }
    public DateTime? ValidTo { get; protected set; }
    public bool IsRevoked { get; protected set; }
    public string? DocumentReference { get; protected set; }
    public virtual AgreementType? AgreementType { get; protected set; }
    public virtual Employee? Employee { get; protected set; }

    protected TimeTrackingAgreement() { }

    public static TimeTrackingAgreement Create()
    {
        return new TimeTrackingAgreement();
    }
}
