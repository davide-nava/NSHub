using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class Iso20022SalaryMessage : BaseEntity
{
    public Guid CheckingAccountId { get; set; }

    public string MessageId { get; set; } = null!;

    public string Xml { get; set; } = null!;

    public MessageType MessageType { get; set; }

    public Guid Iso20022SalaryMessageCategoryId { get; set; }

    public virtual CheckingAccount? CheckingAccount { get; set; }
    public virtual Iso20022SalaryMessageCategory? Iso20022SalaryMessageCategory { get; set; }

    public DateTime LoadingDate { get; set; }

    public DateTime MessageStartDate { get; set; }

    public DateTime MessageEndDate { get; set; }

    public ProcessingStatusType ProcessingStatusType { get; set; }

    public TransmissionModeType TransmissionModeType { get; set; }

    public bool InUse { get; set; }

    public string EbicsTransaction { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
