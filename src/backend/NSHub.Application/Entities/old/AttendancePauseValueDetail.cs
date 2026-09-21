using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendancePauseValueDetail : BaseEntity
{
    public Guid AttendancePauseValueId { get; set; }

    public int From { get; set; }

    public int Value { get; set; }

    public virtual AttendancePauseValue? AttendancePauseValue { get; set; }
}
