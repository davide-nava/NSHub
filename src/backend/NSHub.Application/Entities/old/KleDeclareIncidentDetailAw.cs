using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class KleDeclareIncidentDetailAw : BaseEntity
{
    public Guid DeclareIncidentDetailId { get; set; }

    public RecordType RecordType { get; set; }

    public Guid SynchronizeRequestByInstitId { get; set; }

    public Guid SynchronizeResponseByCompanyId { get; set; }

    public DateTime Expiration { get; set; }

    public Guid SynchronizeContentId { get; set; }

    public virtual DeclareIncidentDetail? DeclareIncidentDetail { get; set; }
    public virtual SynchronizeRequestByInstit? SynchronizeRequestByInstit { get; set; }
    public virtual SynchronizeResponseByCompany? SynchronizeResponseByCompany { get; set; }
    public virtual SynchronizeContent? SynchronizeContent { get; set; }


}
