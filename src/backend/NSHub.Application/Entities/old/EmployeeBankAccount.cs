using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EmployeeBankAccount : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string Iban { get; set; } = null!;

    public string Swift { get; set; } = null!;

    public string Number { get; set; } = null!;

    public IEnumerable<StringList> Banks { get; set; }


    public string Npa { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string Nation { get; set; } = null!;

    public int TransferCharges { get; set; }

    public bool ChkClearing { get; set; }

    public bool ChkIban { get; set; }

    public bool ChkPvr { get; set; }

    public string NationIso2 { get; set; } = null!;

    public bool EnableSepa { get; set; }

    public string Qriban { get; set; } = null!;

    public decimal AmountLimit { get; set; }

    public BankAccountPriority BankAccountPriority { get; set; }

    public bool ChkInCash { get; set; }

    public string Qrreference { get; set; } = null!;

    public string Currency { get; set; } = null!;


    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Employee? Employee { get; set; }

}
