using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class MedidataTicket : BaseEntity
{

    public Guid CorrespondentCorrelationLinkEntryId { get; set; }

    public string CaseNumber { get; set; } = null!;

    // TODO: Check type
    public int MedidataReason { get; set; }

    public DateTime CaseDate { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public string Diagnosis { get; set; } = null!;


    public virtual CorrespondentCorrelationLinkEntry? IdCorrespondentCorrelationLinkEntryNavigation { get; set; }
}
