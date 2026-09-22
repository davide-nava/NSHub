using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class RunnableInstancesTable : BaseEntity
{
    public Guid SurrogateInstanceId { get; set; }

    public WorkflowHostType? WorkflowHostType { get; set; }

    public Guid? ServiceDeploymentId { get; set; }

    public DateTime RunnableTime { get; set; }

    public Guid SurrogateIdentityId { get; set; }

    public virtual SurrogateInstance? SurrogateInstance { get; set; }
    public virtual ServiceDeployment? ServiceDeployment { get; set; }
    public virtual SurrogateIdentity? SurrogateIdentity { get; set; }

}
