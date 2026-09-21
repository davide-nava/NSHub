using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class BookmarkResource : BaseEntity
{

    public Guid BookmarkManagementId { get; set; }

    public Guid EmployeeId { get; set; }

    public ActionType ActionType { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual BookmarkManagement? BookmarkManagement { get; set; }


}
