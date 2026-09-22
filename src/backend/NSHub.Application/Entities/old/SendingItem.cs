using System;
using System.Collections.Generic;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SendingItem : BaseEntity
{
    public RecipientType RecipientType { get; set; }

    public Guid CorrespondentId { get; set; }

    public Guid SubjectId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime DateTimeSent { get; set; }

    public StatusType SendingItemStatusType { get; set; }

    public Guid SendingId { get; set; }

    public Guid DocumentId { get; set; }

    public string Recipient { get; set; } = null!;

    public Guid ArticleId { get; set; }

    public Guid JobEntryId { get; set; }

    public Guid MailBodyId { get; set; }

    public Guid ActivityProgressId { get; set; }

    public Guid ActivityId { get; set; }

    public Guid DocumentManagementId { get; set; }

    public Guid RecallSendingId { get; set; }

    public Guid CostCenterId { get; set; }

    public string AlternativeSubject { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Sending? Sending { get; set; }

}
