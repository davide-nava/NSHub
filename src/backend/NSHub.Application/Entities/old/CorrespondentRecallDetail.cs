using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CorrespondentRecallDetail : BaseEntity
{

    public Guid CorrespondentId { get; set; }

    public string IdSubjects { get; set; } = null!;

    public string EmailAddresses { get; set; } = null!;

    public bool SendToCorrespondentMail { get; set; }

    public CorrespondentRecallDetailType CorrespondentRecallDetailType { get; set; }

    public virtual Correspondent? Correspondent { get; set; }

}
