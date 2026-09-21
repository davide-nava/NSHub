using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Parameter : BaseEntity
{
    public string Key { get; set; } = null!;

    public string CodeLanguage { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string CodeUser { get; set; } = null!;

}
