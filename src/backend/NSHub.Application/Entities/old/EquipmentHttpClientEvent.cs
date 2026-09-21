using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class EquipmentHttpClientEvent : BaseEntity
{
    public Guid EquipmentId { get; set; }

    public DateTime DateAndTime { get; set; }

    public string MacAddress { get; set; } = null!;

    public EventType EventType { get; set; }


    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }
    public virtual Equipment? Equipment { get; set; }
}
