using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AutomaticImportHeader : BaseEntity
{
    public Guid TableId { get; set; }

    public string Folder { get; set; } = null!;

    public bool IsActive { get; set; }

    public int LedgerGender { get; set; }

    public bool IsInsert { get; set; }

    public string Users { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Table? Table { get; set; }

}
