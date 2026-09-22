namespace NSHub.ApplicationCore.Entities;

public class SalaryConstantCategoryType : BaseEntityType
{
    public Guid SalaryConstantTypeId { get; set; }

    public virtual SalaryConstantType? SalaryConstantType { get; set; }
}
