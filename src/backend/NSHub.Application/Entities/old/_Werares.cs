using NSHub.ApplicationCore.Entities;

namespace NSHub.ApplicationCore.Entities;

public class Warehouse : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid WarehouseTypeId { get; set; }

    public virtual WarehouseType? WarehouseType { get; set; }

    public bool IsAlertStockUnderZero { get; set; }

    public bool IsAlertStockUnderMin { get; set; }

    public bool IsAlertAvailUnderZero { get; set; }

    public bool IsAlertAvailUnderMin { get; set; }

    public bool ShowOnEvasion { get; set; }

    public bool AddOnNewArticle { get; set; }

    public bool ExcludeForSpecialValues { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
