using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalarySwissdecStatisticValidity : BaseEntity
{
    public DateTime ValidityDate { get; set; }

    public string ElmVersion { get; set; } = null!;

}
