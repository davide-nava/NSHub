using System;
using System.Collections.Generic;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentSubject : BaseEntity
{
    public Guid CorrespondentId { get; set; }

    public string Email { get; set; } = null!;

    public int IdentificationNumber { get; set; }

    public int Level { get; set; }

    public string Name { get; set; } = null!;

    public bool NotActive { get; set; }

    public string Notes { get; set; } = null!;

    public string OfficeFax { get; set; } = null!;

    public string OfficePlace { get; set; } = null!;

    public string OfficeTelephone { get; set; } = null!;

    public string PersonalAddress { get; set; } = null!;

    public string PersonalLocality { get; set; } = null!;

    public string PersonalPostalCode { get; set; } = null!;

    public string PersonalProvince { get; set; } = null!;

    public string PersonalTelephone { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Groups { get; set; } = null!;

    public string RefExternal { get; set; } = null!;

    public string IdentificationCode { get; set; } = null!;

    public Guid UserId { get; set; }

    public string Password { get; set; } = null!;

    public bool ChangePasswordNextLogin { get; set; }

    public bool UnsubscribedFromEmails { get; set; }

    public virtual Correspondent? Correspondent { get; set; }

    public virtual User? User { get; set; }

}
