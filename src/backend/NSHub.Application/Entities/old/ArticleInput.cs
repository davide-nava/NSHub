using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ArticleInput : BaseEntity
{
    public string Code { get; set; } = null!;

    public StatusType StatusType { get; set; }

    public DateTime InputDate { get; set; }
}
