using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class Equipment : BaseEntity
{
    public short BadgePositionStart { get; set; }

    public string LocalIpaddress { get; set; } = null!;

    public int LocalIpport { get; set; }

    public short SerialPort { get; set; }

    public int SerialSpeed { get; set; }

    public short BadgeLenght { get; set; }

    public EquipmentType EquipmentType { get; set; }

    public string LocalDnsserver { get; set; } = null!;

    public LinkType LinkType { get; set; }

    public int Number { get; set; }

    public Guid HolidayHeaderId { get; set; }

    public string HolidayTypes { get; set; } = null!;

    public int SendNextDays { get; set; }

    public string FtpServer { get; set; } = null!;

    public string FtpUser { get; set; } = null!;

    public string FtpPassword { get; set; } = null!;

    public string FtpPath { get; set; } = null!;

    public string ServerIpclocking { get; set; } = null!;

    public bool ActivateHttpHttps { get; set; }

    public string MacAddress { get; set; } = null!;

    public bool DownloadByRecord { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
