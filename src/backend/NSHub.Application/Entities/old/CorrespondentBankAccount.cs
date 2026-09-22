using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class CorrespondentBankAccount : BaseEntity
{
    public Guid CorrespondentId { get; set; }

    public int TransferCharges { get; set; }

    public PriorityType PriorityType { get; set; }

    public string Iban { get; set; } = null!;

    public string Swift { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string PostalNumber { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public string Npa { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string Nation { get; set; } = null!;

    public string FollowerNumber { get; set; } = null!;

    public bool ChkClearing { get; set; }

    public bool ChkIban { get; set; }

    public bool ChkPostalNumber { get; set; }

    public bool ChkPvr { get; set; }

    public string NationIso2 { get; set; } = null!;

    public string ParticipantNumber { get; set; } = null!;

    public bool EnableSepa { get; set; }

    public bool IsDefault { get; set; }

    public string Qriban { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Correspondent? Correspondent { get; set; }
}
