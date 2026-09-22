using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class EbicsConfiguration : BaseEntity
{
    public string Name { get; set; } = null!;

    public string ServerAddress { get; set; } = null!;

    public string HostId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string PartnerId { get; set; } = null!;

    public string UserAuthenticationCertificateThumbprint { get; set; } = null!;

    public string UserEncryptionCertificateThumbprint { get; set; } = null!;

    public string UserSignatureCertificateThumbprint { get; set; } = null!;

    public string UserCertificatesFolderPath { get; set; } = null!;

    public string UserCertificatesPassword { get; set; } = null!;

    public StatusType StatusType { get; set; }

    public string BankAuthenticationPublicKey { get; set; } = null!;

    public string BankEncryptionPublicKey { get; set; } = null!;

    public string BankAuthenticationCertificate { get; set; } = null!;

    public string BankEncryptionCertificate { get; set; } = null!;

    public bool ImportOnlyAssociatedCheckingAccountsFiles { get; set; }

}
