using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentOutlookContactMap : BaseEntity
{
    public string Correspondent { get; set; } = null!;

    public string OutlookContact { get; set; } = null!;

    public int Token { get; set; }

    public bool Key { get; set; }

}
