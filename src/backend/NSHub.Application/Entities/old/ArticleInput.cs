using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleInput : BaseEntity
{
    public string Code { get; set; } = null!;

    public StatusType StatusType { get; set; }

    public DateTime InputDate { get; set; }
}
