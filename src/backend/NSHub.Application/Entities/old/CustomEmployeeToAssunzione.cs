using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomEmployeeToAssunzione : BaseEntity
{
    public Guid CustomEmployeeToAssunzioneParentId { get; set; }

    public int CustomPeriodo { get; set; }

    public IEnumerable<IntList> CustomLivelloAuts { get; set; }

    public IEnumerable<DateTimeList> CustomDataEsecuzioni { get; set; }
    public IEnumerable<BoolList> CustomAttivi { get; set; }
    public IEnumerable<IntList> CustomSelezioni { get; set; }
    public IEnumerable<BoolList> CustomInviaMails { get; set; }

    public IEnumerable<GuidList> CustomTestoTipi { get; set; }

    public IEnumerable<IntList> CustomSelezioni { get; set; }

    public IEnumerable<TranslationGroupList> CustomDescriptions { get; set; }

    public string CustomStato { get; set; } = null!;

}
