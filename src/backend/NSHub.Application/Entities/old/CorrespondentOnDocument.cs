using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentOnDocument : BaseEntity
{
    public Guid DocumentManagementId { get; set; }

    public Guid CorrespondentId { get; set; }

    public Guid CorrespondentCorrelationTypeId { get; set; }

    public IEnumerable<StringGroupList> Names { get; set; }


    public string Address { get; set; } = null!;

    public string AddressPostOfficeBox { get; set; } = null!;

    public string AddressPostalCode { get; set; } = null!;

    public string AddressLocality { get; set; } = null!;

    public string District { get; set; } = null!;

    public string AddressNation { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string AttentionTo { get; set; } = null!;

    public string Code { get; set; }

    public virtual DocumentManagement? DocumentManagement { get; set; }
    public virtual Correspondent? Correspondent { get; set; }
    public virtual CorrespondentCorrelationType? CorrespondentCorrelationType { get; set; }

}
