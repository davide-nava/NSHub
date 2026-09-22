using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class RecallMovement : BaseEntity
{
    public Guid DocumentInstallmentId { get; set; }

    public RecallLevelType RecallLevelType { get; set; }

    public DateTime InputDate { get; set; }

    public Guid RecallSendingId { get; set; }

    public Guid RecallGroupId { get; set; }

    public virtual DocumentInstallment? DocumentInstallment { get; set; }

    public virtual RecallSending? RecallSending { get; set; }

    public virtual RecallGroup? RecallGroup { get; set; }

}
