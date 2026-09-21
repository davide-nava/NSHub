using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Wordprocessing;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeMarriagePartner : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime ValidFrom { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string AddressLocality { get; set; } = null!;

    public string AddressNation { get; set; } = null!;

    public string AddressDistrict { get; set; } = null!;

    public string AddressPostOfficeBox { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public string AddressComplementary { get; set; } = null!;

    public string AddressPostalCode { get; set; } = null!;

    public string SocialInsuranceNumber { get; set; } = null!;

    public bool WorkOrCompensatory { get; set; }

    public Guid WorkCantonId { get; set; }

    public DateTime WorkStartDate { get; set; }

    public DateTime WorkEndDate { get; set; }

    public virtual Canton? Canton { get; set; }
    public virtual Employee? Employee { get; set; }

}
