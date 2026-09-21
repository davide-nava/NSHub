using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeBankAccountBeneficiary : BaseEntity
{
    public Guid EmployeeBankAccountId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Npa { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public virtual EmployeeBankAccount EmployeeBankAccount { get; set; } = null!;
}
