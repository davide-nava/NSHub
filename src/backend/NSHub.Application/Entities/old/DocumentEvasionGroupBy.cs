using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentEvasionGroupBy : BaseEntity
{
    public Guid DocumentEvasionConfigurationId { get; set; }

    public GroupByType GroupByType { get; set; }

    public int IntValue { get; set; }

    public string StrValue { get; set; } = null!;

    public int Order { get; set; }

    public bool IsGroupingCorrespondent { get; set; }

    public virtual DocumentEvasionConfiguration? DocumentEvasionConfiguration { get; set; }

}
