using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleLotHandling : BaseEntity
{
    public Guid ArticleLotDetailId { get; set; }

    public Guid ArticleHandlingId { get; set; }

    public virtual ArticleHandling? ArticleHandling { get; set; }

    public virtual ArticleLotDetail? ArticleLotDetail { get; set; }
}
