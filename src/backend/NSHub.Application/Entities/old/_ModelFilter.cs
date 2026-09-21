using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ModelFilter : BaseEntity
{
    public string Code { get; set; } = null!;

    public string FieldName { get; set; } = null!;

    public string FieldTarget { get; set; } = null!;

    public string ModelQuery { get; set; } = null!;

    public string ModelSelectionCondition { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
