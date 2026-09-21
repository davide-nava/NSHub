using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeChildrenSalaryParameter : BaseEntity
{
    public Guid EmployeeChildrenId { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime FamilyIncomeStart { get; set; }

    public DateTime FamilyIncomeEnd { get; set; }

    public FamilyIncomeType FamilyIncomeType { get; set; }

    public decimal FamilyIncomeAmountBase { get; set; }

    public decimal FamilyIncomeAmountStudy { get; set; }

    public bool EnableTaxAtSource { get; set; }

    public DateTime TaxAtSourceFrom { get; set; }

    public DateTime TaxAtSourceTo { get; set; }

    public bool DomesticResidence { get; set; }

    public virtual EmployeeChild? EmployeeChildren { get; set; }


}
