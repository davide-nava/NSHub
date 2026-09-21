using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class KleDeclareIncidentDetail : BaseEntity
{
    public Guid DeclareIncidentId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid EmployeeHrId { get; set; }

    public Guid InsuranceId { get; set; }

    public Guid InsuranceTypeId { get; set; }

    public virtual DeclareIncident? DeclareIncident { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual EmployeeHr? EmployeeHr { get; set; }
    public virtual Insurance? Insurance { get; set; }
    public virtual InsuranceType? InsuranceType { get; set; }


    public string CompanyCaseId { get; set; } = null!;

    public string InsuranceCaseId { get; set; } = null!;

    public string IncidentCaseId { get; set; } = null!;

    public StatusType StatusType { get; set; }

    public string InsuranceCodes { get; set; } = null!;

    public string IncidentOrRelapseContent { get; set; } = null!;

    public Guid DescriptionMessageId { get; set; }

    public virtual TranslationGroup? DescriptionMessage { get; set; }

    public Guid DescriptionInfoId { get; set; }
    public virtual TranslationGroup? DescriptionInfo { get; set; }

    public Guid DescriptionWarningId { get; set; }

    public virtual TranslationGroup? DescriptionWarning { get; set; }
    public Guid DescriptionErrorId { get; set; }

    public virtual TranslationGroup? DescriptionError { get; set; }


    public string RequestId { get; set; } = null!;

    public string ResponseId { get; set; } = null!;

    public Guid DigitalizationScopeId { get; set; }

    public bool EmployeeDataMismatch { get; set; }

    public bool IsClosed { get; set; }

    public string DeliverContractIdentity { get; set; } = null!;

    public string DeliverCustomerIdentity { get; set; } = null!;


    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public InsuranceStatusType InsuranceStatusType { get; set; }

}
