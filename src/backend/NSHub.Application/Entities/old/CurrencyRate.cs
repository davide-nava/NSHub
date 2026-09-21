using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CurrencyRate : BaseEntity
{
    public decimal Rate { get; set; }

    public Guid ValidityId { get; set; }

    public Guid CurrencyId { get; set; }
    public Guid CurrencyRangeId { get; set; }

    public CurrencyType CurrencyType { get; set; }

    public int Origin { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual Validity? Validity { get; set; }
    public virtual CurrencyRange? CurrencyRange { get; set; }

}
