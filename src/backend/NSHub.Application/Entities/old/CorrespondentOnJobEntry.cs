using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CorrespondentOnJobEntry : BaseEntity
{

    public Guid JobEntryId { get; set; }

    public Guid CorrespondentId { get; set; }

    public Guid CorrespondentCorTypeId { get; set; }

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

    public virtual JobEntry? JobEntry { get; set; }
    public virtual Correspondent? Correspondent { get; set; }
    public virtual CorrespondentCorType? CorrespondentCorType { get; set; }
}
