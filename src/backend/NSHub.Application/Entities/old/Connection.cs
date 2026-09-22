using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Connection : BaseEntity
{
    public ConnectionType ConnectionType { get; set; }

    public string Address { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NameDisplayed { get; set; } = null!;

    public int Port { get; set; }

    public bool UseSsl { get; set; }

    public string User { get; set; } = null!;

    public string AddressImap { get; set; } = null!;

    public int PortImap { get; set; }

    public string BlockedUsers { get; set; } = null!;

    public string AadApplication { get; set; } = null!;

    public string AadTenant { get; set; } = null!;

    public string AadSecretClient { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
