using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class RentalProcessed : BaseEntity
{

    public Guid RentalArticleId { get; set; }

    public Guid DossierRowId { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public virtual RentalArticle? RentalArticle { get; set; }

    public virtual DossierRow? DossierRow { get; set; }

}
