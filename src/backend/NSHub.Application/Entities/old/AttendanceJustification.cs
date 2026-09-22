using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceJustification : BaseEntity
{
    public Guid AccountId { get; set; }

    public Guid AttendanceId { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public Guid AbsenceRequestSourceId { get; set; }

    public bool HasUserModifiedJustification { get; set; }

    public int Quantity { get; set; }

    public virtual Attendance? Attendance { get; set; }
    public virtual Account? Account { get; set; }
    public virtual AbsenceRequestSource? AbsenceRequestSource { get; set; }
}
