using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputingHtInsurance : BaseEntity
{
    public Guid SalaryHeadComputingId { get; set; }

    public Guid InsuranceAvsId { get; set; }

    public Guid InsuranceLainfId { get; set; }

    public IEnumerable<GuidList> InsuranceLainfCs { get; set; }
    public IEnumerable<GuidList> InsuranceIgms { get; set; }

    public IEnumerable<GuidList> InsuranceLpps { get; set; }
    public IEnumerable<StringList> InsuranceCodeLainfs { get; set; }
    public IEnumerable<StringList> InsuranceCodeIgms { get; set; }
    public IEnumerable<StringList> InsuranceLppcategories { get; set; }


    public IEnumerable<GuidList> InsuranceLppTypes { get; set; }

    public IEnumerable<DecimalList> InsuranceLppemployees { get; set; }

    public string Avscode { get; set; }

    public bool IsAvsSpecialCode { get; set; }

    public bool IsAvsSpecialCase { get; set; }

    public bool AvsWaiveOfPensionDeduct { get; set; }

    public string AdCode { get; set; }

    // TODO: Check type
    public int CafWorkplaceCanton { get; set; }

    public Guid InsuranceCafId { get; set; }

    public Guid InsuranceCpcId { get; set; }

    public Guid InsurancePeanId { get; set; }

    public virtual SalaryHeadComputing? SalaryHeadComputing { get; set; }
}
