using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class KeysTable : BaseEntity
{
    public Guid SurrogateKeyId { get; set; }

    public Guid? SurrogateInstanceId { get; set; }

    public byte? EncodingOption { get; set; }

    public byte[]? Properties { get; set; }

    public bool? IsAssociated { get; set; }

    public virtual SurrogateKey? SurrogateKey { get; set; }
    public virtual SurrogateInstance? SurrogateInstance { get; set; }

}
