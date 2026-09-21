using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class GlAccount : BaseEntity
{
    public int GlAccountId { get; set; }

    public int CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public bool IsPostingAllowed { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<GlJournalLine> GlJournalLines { get; set; } = [];

    public virtual ICollection<ItemGroup> ItemGroupCostAccounts { get; set; } = [];

    public virtual ICollection<ItemGroup> ItemGroupInventoryAccounts { get; set; } = [];

    public virtual ICollection<ItemGroup> ItemGroupRevenueAccounts { get; set; } = [];
    public virtual ICollection<TaxCode> TaxCodes { get; set; } = [];
}
