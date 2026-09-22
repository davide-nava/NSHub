using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Wordprocessing;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalarySwissdecLogRecipient : BaseEntity
{
    public Guid WorkplaceAgencyId { get; set; }

    public Guid InsuranceNameId { get; set; }

    public StatusType SalarySwissdecLogRecipientStatusType { get; set; }

    public Guid CantonId { get; set; }

    public virtual WorkplaceType? Workplace { get; set; }
    public virtual InsuranceName? InsuranceName { get; set; }
    public virtual Canton? Canton { get; set; }

    public bool IsCompleted { get; set; }

    public string CompletionUrl { get; set; } = null!;

    public string CompletionKey { get; set; } = null!;

    public string CompletionPassword { get; set; } = null!;

    public Guid DetailGetResultId { get; set; }

    public virtual DetailGetResult? DetailGetResult { get; set; }

    public bool IsDistributed { get; set; }

    public bool IsGetStatusExecuted { get; set; }

    public StatusType CompletionOperationStatus { get; set; }

    public bool IsGetResultExecuted { get; set; }

    public bool HasUserFinished { get; set; }

    public StatusType GetDialogOperationStatus { get; set; }

    public bool IsReplyDialogExecuted { get; set; }


    public RecipientType RecipientType { get; set; }


}
