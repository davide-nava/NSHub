using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ExchangeRate : BaseEntity
{
    public int ExchangeRateId { get; set; }

    public string FromCurrencyCode { get; set; } = null!;

    public string ToCurrencyCode { get; set; } = null!;

    public decimal Rate { get; set; }

    public DateOnly ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public virtual Currency FromCurrencyCodeNavigation { get; set; } = null!;

    public virtual Currency ToCurrencyCodeNavigation { get; set; } = null!;
}
