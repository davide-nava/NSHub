using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowInstanceUser : BaseEntity
{
    public Guid WorkflowInstanceId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ApprovationStatusTypeId { get; set; }

    public virtual ApprovationStatusType? ApprovationStatusType { get; set; }

    public bool IsActive { get; set; }

    public Guid NoteId { get; set; }

    public virtual Translation? Note { get; set; }

    public DateTime Date { get; set; }

    public Guid EmployeeApprovatorId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual WorkflowInstance? WorkflowInstance { get; set; }

    public virtual Employee? EmployeeApprovator { get; set; }
}
