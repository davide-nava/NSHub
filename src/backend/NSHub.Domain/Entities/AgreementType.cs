using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AgreementType : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    private readonly List<TimeTrackingAgreement> _timeTrackingAgreements = new();
    public virtual IReadOnlyCollection<TimeTrackingAgreement> TimeTrackingAgreements => _timeTrackingAgreements.AsReadOnly();

    protected AgreementType() { }

    public static AgreementType Create()
    {
        return new AgreementType();
    }
}
