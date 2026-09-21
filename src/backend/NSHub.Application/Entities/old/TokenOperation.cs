using System;

namespace PlanetHub.ApplicationCore.Entities;

public class TokenOperation : BaseEntity
{
    public string Token { get; set; } = null!;

    public Guid TokenOperationTypeId { get; set; }

    public virtual TokenOperationType? TokenOperationType { get; set; }

    public string OperationData { get; set; } = null!;

    public DateTime Creation { get; set; }

    public DateTime Execution { get; set; }

    public Guid TokenOperationStatusTypeId { get; set; }

    public virtual TokenOperationStatusType? TokenOperationStatusType { get; set; }
}
