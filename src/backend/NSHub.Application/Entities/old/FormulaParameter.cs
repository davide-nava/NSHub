using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class FormulaParameter : BaseEntity
{
    public string ParameterName { get; set; } = null!;

    public Guid CodeFormulaCategoryId { get; set; }

    public DataType DataType { get; set; }

    public string Value { get; set; } = null!;

    public Guid FormulaId { get; set; }

    public virtual Formula? Formula { get; set; }
    public virtual CodeFormulaCategory? CodeFormulaCategory { get; set; }
}
