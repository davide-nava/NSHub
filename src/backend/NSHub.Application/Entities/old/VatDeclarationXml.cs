using System;

namespace PlanetHub.ApplicationCore.Entities;

public class VatDeclarationXml : BaseEntity
{
    public string BusinessRefId { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public string XmlContent { get; set; } = null!;

    public Guid SubmissionTypeId { get; set; }

    public virtual SubmissionType? SubmissionType { get; set; }
}
