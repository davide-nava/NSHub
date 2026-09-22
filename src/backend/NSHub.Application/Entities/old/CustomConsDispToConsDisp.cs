using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomConsdispToConsdisp : BaseEntity
{
    public Guid CustomConsdispToConsdispParentId { get; set; }

    public Guid CustomDispositivoAssId { get; set; }

    public Guid CustomRisorsaId { get; set; }

    public DateTime CustomDataConfermaCo { get; set; }

    public Guid CustomStatoConsegnaId { get; set; }

    public DateTime CustomDataConsegna { get; set; }

    public Guid CustomRedattoreId { get; set; }

    public Guid DescriptionCustomNoteApprId { get; set; }

    public virtual TranslationGroup? DescriptionCustomNoteAppr { get; set; }

    public Guid DescriptionCustomNoteId { get; set; }

    public virtual TranslationGroup? DescriptionCustomNote { get; set; }
}
