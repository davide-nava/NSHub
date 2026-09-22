using System;
using System.Collections.Generic;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Numerator : BaseEntity
{
    public NumeratorType NumeratorType { get; set; }

    public Guid TableId { get; set; }

    public string FieldName { get; set; } = null!;

    public string Root { get; set; } = null!;

    public int LastIndex { get; set; }

    public int IndexDigits { get; set; }

    public GenderType GenderType { get; set; }

    public bool IsYearly { get; set; }

    public bool IsDateProgressive { get; set; }

    public bool IsWithoutHoles { get; set; }

    public bool IsUnique { get; set; }

    public bool IsUniqueLocked { get; set; }

    public NumeratorSubType NumeratorSubType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual Table? Table { get; set; }

}
