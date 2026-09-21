using PlanetHub.ApplicationCore.Entities.Json;

namespace PlanetHub.ApplicationCore.Entities;

public class SupportLotDetail : BaseEntity
{
    public Guid ArticleLotId { get; set; }

    public decimal Quantity { get; set; }

    public IEnumerable<DecimalListJson> Amounts { get; set; }

    public string SessionGuid { get; set; } = null!;

    public virtual ArticleLot? ArticleLot { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public IEnumerable<TranslationGroupListJson> Texts { get; set; }
}
