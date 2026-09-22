using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryValue : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public int Position { get; set; }

    public Guid SalaryConstantId { get; set; }

    public DateTime ValidFrom { get; set; }

    public decimal Value { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual SalaryConstant? SalaryConstant { get; set; }
}
