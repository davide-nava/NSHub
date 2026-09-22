using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ImportLayout : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Layout { get; set; } = null!;

    public LayoutType LayoutType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
