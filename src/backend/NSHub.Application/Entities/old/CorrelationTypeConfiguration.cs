using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrelationTypeConfiguration : BaseEntity
{
    public ObjectType ObjectType { get; set; }

    public Guid CorrelationTypeId { get; set; }

    public Guid ConfigurationTypeId { get; set; }

    public bool IsPrimary { get; set; }

    public bool UsePrice { get; set; }

    public Guid FilterGroupId { get; set; }

    public bool IsDefaultCorrelationType { get; set; }

    public bool IsBilling { get; set; }

    public bool ShippingAddress { get; set; }

    public MandatoryModeType MandatoryModeType { get; set; }

    public string CorrespondentBlockCondition { get; set; } = null!;

    public bool IsGenericObjectHolder { get; set; }

    public bool UsePrimaryWithoutCorrelation { get; set; }

    public bool IsDocumentDelivery { get; set; }


    public virtual FilterGroup? FilterGroup { get; set; }
    public virtual CorrelationType? CorrelationType { get; set; }
    public virtual ConfigurationType? ConfigurationType { get; set; }


}
