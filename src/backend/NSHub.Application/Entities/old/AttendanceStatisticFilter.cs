using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceStatisticFilter : BaseEntity
{
    public Guid AttendanceStatisticGroupId { get; set; }

    public string Filter { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual AttendanceStatisticGroup? AttendanceStatisticGroup { get; set; }
}
