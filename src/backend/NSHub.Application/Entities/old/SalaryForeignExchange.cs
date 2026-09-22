using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryForeignExchange : BaseEntity
{
    public Guid CurrencyId { get; set; }

    public Guid ExchangeRateId { get; set; }

    public Guid NetSalaryId { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ExchangeRate? ExchangeRate { get; set; }

    public virtual NetSalary? NetSalary { get; set; }
}
