using System.Collections.Generic;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Grid : BaseEntity
{
    public string Code { get; set; } = null!;

    public string Davers { get; set; } = null!;

}
