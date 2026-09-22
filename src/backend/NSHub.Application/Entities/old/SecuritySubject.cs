using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SecuritySubject : BaseEntity
{
    public Guid SourceId { get; set; }

    public SourceType SourceType { get; set; }
}
