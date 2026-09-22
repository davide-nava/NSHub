using System;
using System.Collections.Generic;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Attachment : BaseEntity
{
    public int CodeOrigin { get; set; }

    public string FileName { get; set; } = null!;

    public Guid EmployeeRedactorId { get; set; }

    public DateTime Date { get; set; }

    public bool IsExtract { get; set; }

    public string Extension { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime EditDate { get; set; }

    public int Direction { get; set; }

    public string Notes { get; set; } = null!;

    public Guid UserLockerId { get; set; }

    public Guid IdContentId { get; set; }

    public bool IsMailMerge { get; set; }

    public int CodeCategory { get; set; }

    public Guid TemplateMailId { get; set; }

    public int CodeMailMerge { get; set; }

    public int SendMail { get; set; }

    public string Number { get; set; } = null!;

    public Guid ConnectionId { get; set; }

    public string Subject { get; set; } = null!;

    public DateTime FileDate { get; set; }

    public string EditFileName { get; set; } = null!;

    public bool IsReadReceiptRequested { get; set; }

    public bool IsDeliveryReceiptRequested { get; set; }

    public StatusType StatusType { get; set; }

    public IEnumerable<TranslationGroupList> Informations { get; set; }


    public bool IsFullOcr { get; set; }

    public int OnEmployeeExit { get; set; }

    public Guid AttachmentWorkflowModelId { get; set; }

    public DateTime DateTimeNotice { get; set; }

    public int NoticeExpiration { get; set; }

    public bool IsNoticeDisabled { get; set; }

    public string NoticeCondition { get; set; } = null!;

    public int CommunicationManagement { get; set; }

    public PlanningType PlanningType { get; set; }

    public string MonthDays { get; set; } = null!;

    public string Months { get; set; } = null!;

    public string WeekDays { get; set; } = null!;

    public string MonthWeeklyOccurrences { get; set; } = null!;

    public PeriodType PeriodType { get; set; }

    public int PeriodCycles { get; set; }

    public DateTime ReferenceDate { get; set; }

    public DateTime EndPeriodicity { get; set; }

    public int DayOutOfBounds { get; set; }

    public string CodeTableOrigin { get; set; } = null!;

    public int HolidayCondition { get; set; }

    public string HolidayType { get; set; } = null!;

    public Guid EmployeeLockerId { get; set; }

    public bool IsExtractZipWhenSendingMail { get; set; }

}
