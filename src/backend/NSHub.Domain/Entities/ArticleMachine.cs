using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleMachine : AuditableTenantEntity
{
    public Guid ArticleId { get; protected set; }
    public Guid? ArticleGroupId { get; protected set; }
    public Guid? MachineId { get; protected set; }
    public decimal Quantity { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual ArticleGroup? ArticleGroup { get; protected set; }
    public virtual Machine? Machine { get; protected set; }

    protected ArticleMachine() { }

    public static ArticleMachine Create()
    {
        return new ArticleMachine();
    }
}
