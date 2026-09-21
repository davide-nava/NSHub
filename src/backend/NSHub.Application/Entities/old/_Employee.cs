using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class Employee : BaseEntity
{
    public int Number { get; set; }

    public DateTime BirthDate { get; set; }


    public string ImportCodeAttendance { get; set; } = null!;

    public string ImportCodeSalary { get; set; } = null!;

    public bool NoExportToSalary { get; set; }

    public int ImportSource { get; set; }

    public string ImportCodePlanet { get; set; } = null!;

    public IEnumerable<StringGroupList> BadgeNumbers { get; set; }

    public string MobileNumber { get; set; } = null!;

    public Guid PlanningResourceId { get; set; }

    public ColorType ColorType { get; set; }

    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string AddressLocality { get; set; } = null!;

    public string AddressNation { get; set; } = null!;

    public string AddressPostalCode { get; set; } = null!;

    public string AddressPostOfficeBox { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public string Groups { get; set; } = null!;

    public bool IsRedactor { get; set; }

    public Guid LinkedUserId { get; set; }

    public SexType SexType { get; set; }

    public Guid JobPermissionId { get; set; }

    public CivilStatusType CivilStatusType { get; set; }

    public string ReferenceHr { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string District { get; set; } = null!;

    public string SocialInsuranceNumber { get; set; } = null!;

    public string SimicNumber { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public string BirthLocality { get; set; } = null!;

    public string BirthNation { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public DateTime CivilStatusValidFrom { get; set; }

    public string SwissLocality { get; set; } = null!;

    public string SwissDistrict { get; set; } = null!;

    public string SwissAddress { get; set; } = null!;

    public string SwissAddressComplementary { get; set; } = null!;

    public string SwissAddressPostalCode { get; set; } = null!;

    public string AddressComplementary { get; set; } = null!;

    public DateTime TestExpiryDate { get; set; }

    public DateTime RemarksUpdateDate { get; set; }

    public DateTime NextInterviewDate { get; set; }

    public DateTime JobPermissionExpiryDate { get; set; }

    public Guid IdentificationDocumentTypeId { get; set; }

    public DateTime IdentificationDocumentExpiryDate { get; set; }

    public string TelephoneOffice { get; set; } = null!;

    public string TelephoneOther { get; set; } = null!;

    public string MobileOffice { get; set; } = null!;

    public string EmailAddressOffice { get; set; } = null!;

    public string Telefax { get; set; } = null!;

    public bool IsRegCategoryCollaborator { get; set; }

    public string NetUsername { get; set; } = null!;

    public string NetPassword { get; set; } = null!;

    public Guid DefaultActivityTypeId { get; set; }

    public string Initials { get; set; } = null!;

    public Guid DefaultWarehouseId { get; set; }

    public string NetPasswordClear { get; set; } = null!;

    public Guid ConnectionId { get; set; }

    public Guid ImageId { get; set; }

    public string ActivityGroups { get; set; } = null!;

    public Guid ActionOnResponseId { get; set; }

    public DateTime DossierRowFromDate { get; set; }

    public bool IsDossierRowFromSpecialDate { get; set; }

    public int DossierRowFromSpecialDate { get; set; }

    public DateTime DossierRowToDate { get; set; }

    public bool IsDossierRowToSpecialDate { get; set; }

    public int DossierRowToSpecialDate { get; set; }

    public string GlnNumber { get; set; } = null!;

    public bool IsUserAdmin { get; set; }

    public string ZrsNumber { get; set; } = null!;

    public bool DeactivateHrregistry { get; set; }

    public string StatisticConfigurations { get; set; } = null!;

    public bool ChangePasswordNextLogin { get; set; }

    public string CustomSn { get; set; } = null!;

    public string CustomDispositivo { get; set; } = null!;

    public string CustomModello { get; set; } = null!;

    public string CustomMarca { get; set; } = null!;

    public string CustomTipoDispositivo { get; set; } = null!;

    public bool ExcludePlanetTslogin { get; set; }

    public DateTime ConventionalEnterDate { get; set; }

    public DateTime ClosingDate { get; set; }

    public string AddressTownTaxIdentification { get; set; } = null!;

    public string SwissTownTaxIdentification { get; set; } = null!;

    public string TaxId { get; set; } = null!;

    public DateTime JobPermissionValidFrom { get; set; }

    public bool UnknownSocialInsuranceNumber { get; set; }

    public string PasswordSalaryDelivery { get; set; } = null!;


}
