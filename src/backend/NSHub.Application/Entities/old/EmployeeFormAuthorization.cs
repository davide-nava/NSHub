using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EmployeeFormAuthorization : BaseEntity
{

    public Guid EmployeeAttendanceJobId { get; set; }

    public int Form { get; set; }

    public Guid WorkflowAuthorizationId { get; set; }

    public AuthorizationModeType AuthorizationModeType { get; set; }

    public virtual WorkflowAuthorization? WorkflowAuthorization { get; set; }

    public virtual EmployeeAttendanceJob? EmployeeAttendanceJob { get; set; }

}
