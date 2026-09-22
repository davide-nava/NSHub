using System;

namespace NSHub.ApplicationCore.Entities;

public class Task : BaseEntity
{
    public DateTime CurrentRun { get; set; }

    public Guid TaskStateTypeId { get; set; }

    public virtual TaskStateType? TaskStateType { get; set; }

    public bool ForceExecute { get; set; }

    public bool ForceTerminate { get; set; }

    public Guid ScheduleId { get; set; }

    public DateTime LastRun { get; set; }

    public int LastRunDuration { get; set; }

    public int LastRunTaskStateTypeId { get; set; }

    public virtual TaskStateType? LastRunTaskStateType { get; set; }

    public DateTime LastUpdate { get; set; }

    public string Name { get; set; } = null!;

    public Guid TaskTypeId { get; set; }

    public virtual TaskType? TaskType { get; set; }

    public Guid AssignedServiceIdentityId { get; set; }

    public bool SendMail { get; set; }

    public decimal SendMailGap { get; set; }

    public DateTime LastMailSentTime { get; set; }

    public int LastMailSentLevel { get; set; }

    public Guid LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public string Progress { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    // TODO: check type
    public virtual AssignedServiceIdentity? AssignedServiceIdentity { get; set; }

    public virtual Schedule? Schedule { get; set; }


}
