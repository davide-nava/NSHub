using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class RentalProcessedDefect : BaseEntity
{
    public Guid RentalProcessedId { get; set; }

    public Guid DossierRowId { get; set; }

    public virtual DossierRow? DossierRow { get; set; }

    public virtual RentalProcessed? RentalProcessed { get; set; }
}
