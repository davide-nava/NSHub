using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class DefinitionIdentityTable : BaseEntity
{
    public Guid SurrogateIdentityId { get; set; }

    public Guid DefinitionIdentityHash { get; set; }

    public Guid DefinitionIdentityAnyRevisionHash { get; set; }

    public string? Name { get; set; }

    public string? Package { get; set; }

    public long? Build { get; set; }

    public long? Major { get; set; }

    public long? Minor { get; set; }

    public long? Revision { get; set; }

}
