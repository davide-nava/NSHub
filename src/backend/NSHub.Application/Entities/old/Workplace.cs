using System;

namespace PlanetHub.ApplicationCore.Entities;

public class Workplace  : BaseEntity
{
    public Guid WorkplaceTypeId { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    // TODO: : Commentare
    public string BurReeNumber { get; set; } = null!;

    public Guid AddressId { get; set; }

    public Address Address { get; set; }

    // TODO: : Commentare, valutae di spostare in address
    public string InHouseId { get; set; } = null!;

    // TODO: : Commentare, valutae di spostare in address
    public string TaxAtSourceId { get; set; } = null!;

    // TODO: : Commentare, valutae di spostare in address
    public string MunicipalityId { get; set; } = null!;

    public virtual WorkplaceType? WorkplaceType { get; set; }
}
