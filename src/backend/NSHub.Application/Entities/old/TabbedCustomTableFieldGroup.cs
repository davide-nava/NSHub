using System;

namespace NSHub.ApplicationCore.Entities;

public class TabbedCustomTableFieldGroup : BaseEntity
{
    public Guid TabbedCustomTableId { get; set; }

    public Guid InputConfigurationId { get; set; }

    public Guid FieldGroupId { get; set; }

    public virtual TabbedCustomTable? TabbedCustomTable { get; set; }

    public virtual InputConfiguration? InputConfiguration { get; set; }

    public virtual FieldGroup? FieldGroup { get; set; }
}
