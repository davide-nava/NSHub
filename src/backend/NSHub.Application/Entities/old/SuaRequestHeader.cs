using System;

namespace NSHub.ApplicationCore.Entities;

public class SuaRequestHeader : BaseEntity
{
    public Guid InsuranceId { get; set; }

    public Guid InsuranceTypeId { get; set; }

    public virtual InsuranceType? InsuranceType { get; set; }

    public string Crid { get; set; } = null!;

    public string CredentialKey { get; set; } = null!;

    public string CredentialPassword { get; set; } = null!;

    public string OneTimePassword { get; set; } = null!;

    public Guid? EntryTypeId { get; set; }

    public virtual EntryType? EntryType { get; set; }

    public DateTime EntryDateTime { get; set; }

    public bool IsRevoked { get; set; }

    public Guid SuaRequestHeaderParentId { get; set; }

    public string RevokePassword { get; set; } = null!;

    public string SuaCertificateThumbprint { get; set; } = null!;

    public string SuaCertificateFolderPath { get; set; } = null!;

    public string SuaCertificatePassword { get; set; } = null!;

    public DateTime SuaCertificateExpirationDate { get; set; }

    public Guid SuaRequestHeaderStatusTypeId { get; set; }

    public virtual SuaRequestHeaderStatusType? SuaRequestHeaderStatusType { get; set; }

    public virtual SuaRequestHeader? SuaRequestHeaderParent { get; set; }

    public virtual Insurance? Insurance { get; set; }

}
