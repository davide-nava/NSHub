using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentTypeDiscount : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid DiscountId { get; set; }

    public virtual DocumentType? DocumentType { get; set; }
    public virtual Discount? Discount { get; set; }

}
