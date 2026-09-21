using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Formula : BaseEntity
{
    public Guid CodeCategory { get; set; }

    public string Text { get; set; } = null!;

    public bool IsManual { get; set; }

    public string Name { get; set; } = null!;

    public RoundingType RoundingType { get; set; }

    public decimal RoundTo { get; set; }

    public bool DoNotRound { get; set; }

}
