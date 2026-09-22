using System;
using System.Collections.Generic;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalarySwissdecStatisticValidity : BaseEntity
{
    public DateTime ValidityDate { get; set; }

    public string ElmVersion { get; set; } = null!;

}
