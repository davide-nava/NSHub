using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class JobPattern : BaseEntity
{
    public string Code { get; set; } = null!;

    public IEnumerable<GuidList> LevelFilters { get; set; }
    public IEnumerable<StringList> LevelIds { get; set; }

    public IEnumerable<GuidList> ExcludeLevelFilters { get; set; }

    public IEnumerable<StringList> ExcludeLevels { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
