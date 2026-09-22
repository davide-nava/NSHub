using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryAccount : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }
    public Guid SalaryForeignExchangeId { get; set; }


    public virtual SalaryForeignExchange? SalaryForeignExchange { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
