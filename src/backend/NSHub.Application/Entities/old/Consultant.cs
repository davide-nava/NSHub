using System;
using System.Collections;

namespace PlanetHub.ApplicationCore.Entities;

public class Consultant : BaseEntity
{
    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public Guid AddressId { get; set; }

    public Guid UserId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual User? User { get; set; }
}
