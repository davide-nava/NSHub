using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ParameterEmployee : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string CodeLanguage { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
