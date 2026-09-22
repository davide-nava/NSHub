using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities.Json;

namespace NSHub.ApplicationCore.Entities;

public class TechnicalReport : BaseEntity
{
    public Guid CorrespondentId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid SignatureId { get; set; }

    public Guid TechnicalReportTypeId { get; set; }

    public Guid TravelCostId { get; set; }

    public DateTime Date { get; set; }

    public string Number { get; set; } = null!;

    public Guid CorrespondentCodeTypeId { get; set; }

    public virtual CorrespondentCodeType? CorrespondentCodeType { get; set; }

    public string CorrespondentTitle { get; set; } = null!;

    public string CorrespondentAddress { get; set; } = null!;

    public string CorrespondentLocality { get; set; } = null!;

    public string CorrespondentPostalCode { get; set; } = null!;

    public string CorrespondentEmail { get; set; } = null!;

    public IEnumerable<StringListJson> ElseOperCorrespondentNamestor { get; set; }

    public string CorrespondentTelephone { get; set; } = null!;

    public string CorrespondentComments { get; set; } = null!;

    public decimal TravelCostQuantity { get; set; }

    public Guid DocumentId { get; set; }

    public decimal TravelCostPrice { get; set; }

    public Guid JobEntryId { get; set; }

    public Guid ActivityPlannedId { get; set; }

    public Guid RevisionId { get; set; }

    public bool IsTravelCostPriceVatIncluded { get; set; }

    public Guid GenericObjectId { get; set; }

    public Guid DocumentTemplateId { get; set; }

    public Guid DocumentSubscriptionId { get; set; }

    // TODO: check type
    public virtual DocumentSubscription? DocumentSubscription { get; set; }

    // TODO: check type
    public virtual DocumentTemplate? DocumentTemplate { get; set; }

    public virtual GenericObject? GenericObject { get; set; }

    // TODO: check type
    public virtual Revision? Revision { get; set; }

    public virtual ActivityPlanned? ActivityPlanned { get; set; }

    public virtual JobEntry? JobEntry { get; set; }

    public virtual Document? Document { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Correspondent? Correspondent { get; set; }

    public virtual Employee? Employee { get; set; }

    // TODO: check type
    public virtual Signature? Signature { get; set; }

    public virtual TechnicalReportType? TechnicalReportType { get; set; }

    // TODO: check type
    public virtual TravelCost? TravelCost { get; set; }

}
