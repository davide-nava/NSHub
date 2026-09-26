// <copyright file="DressingName3.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DressingName3 : AuditableTenantEntity
{
    public Guid LanguageId { get; protected set; }
    public string WorkSpiende { get; protected set; } = string.Empty;
    public string OptHfSpindle { get; protected set; } = string.Empty;
    public string OptNormSpendle { get; protected set; } = string.Empty;
    public string Direction { get; protected set; } = string.Empty;
    public string Hf { get; protected set; } = string.Empty;
    public string WheelHand { get; protected set; } = string.Empty;

    protected DressingName3() { }

    public static DressingName3 Create()
    {
        return new DressingName3();
    }
}
