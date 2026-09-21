using System;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowAuthorization : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public string EmployeesSelectionCondition { get; set; } = null!;

    public Guid EmployeesSelectionModeTypeId { get; set; }

    public virtual EmployeesSelectionModeType? EmployeesSelectionModeType { get; set; }

    public int Levels { get; set; }

    public Guid PriorityTypeId { get; set; }

    public virtual PriorityType? PriorityType { get; set; }

    public bool IncludeEmptyElements { get; set; }

    // TODO: commentare
    public int EmployeesNotPresent { get; set; }

    public Guid WorkflowAuthorizationTypeId { get; set; }

    public virtual WorkflowAuthorizationType? WorkflowAuthorizationType { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
