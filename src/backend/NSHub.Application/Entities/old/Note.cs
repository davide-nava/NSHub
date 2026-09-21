namespace PlanetHub.ApplicationCore.Entities;

public class Note : BaseEntity
{
    public DateTime Date { get; set; }

    public Guid NoteTypeId { get; set; }

    public virtual NoteType? NoteType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
