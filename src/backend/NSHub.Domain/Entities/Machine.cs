// <copyright file="Machine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a machine.
/// </summary>
public class Machine : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the machine notes.
    /// </summary>
    public string Notes { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the machine number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the warranty expiration date.
    /// </summary>
    public DateTime WarrantyEndDate { get; set; }

    /// <summary>
    /// Gets or sets the machine acceptance date.
    /// </summary>
    public DateTime AcceptanceDate { get; set; }

    /// <summary>
    /// Gets or sets the delivery date.
    /// </summary>
    public DateTime DeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets the machine description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer code.
    /// </summary>
    public string CustomerCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer name.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the pneumatic configuration.
    /// </summary>
    public string Pneumatic { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the hydraulic configuration.
    /// </summary>
    public string Hydraulic { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the workpiece probe configuration.
    /// </summary>
    public string WorkpieceProbe { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the wheel probe configuration.
    /// </summary>
    public string WheelProbe { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Nakanishi configuration.
    /// </summary>
    public string Nakanishi { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the HH configuration.
    /// </summary>
    public string Hh { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timing belt configuration.
    /// </summary>
    public string TBelt { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the clutch configuration.
    /// </summary>
    public string Clutch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the axis U configuration.
    /// </summary>
    public string AxisU { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the spindle code.
    /// </summary>
    public string SpindleCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the wheel motor code.
    /// </summary>
    public string WheelMotorCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the PC configuration.
    /// </summary>
    public string Pc { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the PC box configuration.
    /// </summary>
    public string PcBox { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the module code.
    /// </summary>
    public string ModuleCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the axis modules configuration.
    /// </summary>
    public string AxisModules { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the safety module configuration.
    /// </summary>
    public string SafetyMod { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the inverter configuration.
    /// </summary>
    public string Inverters { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the machine builder identifier.
    /// </summary>
    public Guid MachineBuilderId { get; set; }

    /// <summary>
    /// Gets or sets the machine type identifier.
    /// </summary>
    public Guid MachineTypeId { get; set; }

    /// <summary>
    /// Gets or sets the PLC type identifier.
    /// </summary>
    public Guid PlcTypeId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the address identifier.
    /// </summary>
    public Guid AddressId { get; set; }

    /// <summary>
    /// Gets or sets the machine temperature.
    /// </summary>
    public decimal Temperature { get; set; }

    /// <summary>
    /// Gets or sets the job order.
    /// </summary>
    public string? JobOrder { get; set; }

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? CustomerEntity { get; set; }

    /// <summary>
    /// Gets or sets the associated machine builder.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual MachineBuilder? MachineBuilder { get; set; }

    /// <summary>
    /// Gets or sets the associated machine type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual MachineType? MachineType { get; set; }

    /// <summary>
    /// Gets or sets the associated PLC type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcType? PlcType { get; set; }

    /// <summary>
    /// Gets or sets the machine address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; set; }

    /// <summary>
    /// Gets or sets the tickets associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Ticket> Tickets { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the interventions associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Intervention> Interventions { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the shipments associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Shipment> Shipments { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the documents associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the ticket status entries associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketStatus> TicketStatuses { get; set; }
        = [];
}
