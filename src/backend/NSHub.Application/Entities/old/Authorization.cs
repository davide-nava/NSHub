using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Authorization : BaseEntity
{
    public string CodeModule { get; set; } = null!;

    public string CodeSection { get; set; } = null!;

    public string CodeOperation { get; set; } = null!;

    public Guid SecuritySubjectId { get; set; }

    public bool IsAuthorized { get; set; }

    public virtual SecuritySubject? SecuritySubject { get; set; }

}
