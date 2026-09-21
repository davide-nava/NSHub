using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class NumeratorDetail : BaseEntity
{
    public Guid NumeratorId { get; set; }

    public int Year { get; set; }

    public int LastIndex { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual Numerator? Numerator { get; set; }
    public virtual Employee? Employee { get; set; }
}
