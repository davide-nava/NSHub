using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class FieldMatchDetail : BaseEntity
{
    public string FieldName { get; set; } = null!;

    // TODO: Check type
    public int Source { get; set; }

    // TODO: Check type
    public int Target { get; set; }

}
