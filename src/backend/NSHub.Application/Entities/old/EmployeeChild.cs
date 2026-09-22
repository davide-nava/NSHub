using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class EmployeeChild : BaseEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public SexType SexType { get; set; }

    public Guid EmployeeId { get; set; }

    public string ReferenceHr { get; set; }

    public string SocialInsuranceNumber { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
