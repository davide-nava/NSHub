using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class EbicsConfigurationDetail : BaseEntity
{
    public Guid EbicsConfigurationId { get; set; }

    public Guid CheckingAccountId { get; set; }

    public bool DownloadAccountStatementEnabled { get; set; }

    public int SendPaymentOrderEnabled { get; set; }

    public virtual CheckingAccount? CheckingAccount { get; set; }

    public virtual EbicsConfiguration? EbicsConfiguration { get; set; }
}
