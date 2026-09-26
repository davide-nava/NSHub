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
    /// Gets the machine notes.
    /// </summary>
    public string Notes { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the machine number.
    /// </summary>
    public string Number { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the warranty expiration date.
    /// </summary>
    public DateTime WarrantyEndDate { get; protected set; }

    /// <summary>
    /// Gets the machine acceptance date.
    /// </summary>
    public DateTime AcceptanceDate { get; protected set; }

    /// <summary>
    /// Gets the delivery date.
    /// </summary>
    public DateTime DeliveryDate { get; protected set; }

    /// <summary>
    /// Gets the machine description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the customer code.
    /// </summary>
    public string CustomerCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the customer name.
    /// </summary>
    public string Customer { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the pneumatic configuration.
    /// </summary>
    public string Pneumatic { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the hydraulic configuration.
    /// </summary>
    public string Hydraulic { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the workpiece probe configuration.
    /// </summary>
    public string WorkpieceProbe { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the wheel probe configuration.
    /// </summary>
    public string WheelProbe { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the Nakanishi configuration.
    /// </summary>
    public string Nakanishi { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the HH configuration.
    /// </summary>
    public string Hh { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the timing belt configuration.
    /// </summary>
    public string TBelt { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the clutch configuration.
    /// </summary>
    public string Clutch { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the axis U configuration.
    /// </summary>
    public string AxisU { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the spindle code.
    /// </summary>
    public string SpindleCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the wheel motor code.
    /// </summary>
    public string WheelMotorCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the PC configuration.
    /// </summary>
    public string Pc { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the PC box configuration.
    /// </summary>
    public string PcBox { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the module code.
    /// </summary>
    public string ModuleCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the axis modules configuration.
    /// </summary>
    public string AxisModules { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the safety module configuration.
    /// </summary>
    public string SafetyMod { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the inverter configuration.
    /// </summary>
    public string Inverters { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the machine builder identifier.
    /// </summary>
    public Guid MachineBuilderId { get; protected set; }

    /// <summary>
    /// Gets the machine type identifier.
    /// </summary>
    public Guid MachineTypeId { get; protected set; }

    /// <summary>
    /// Gets the PLC type identifier.
    /// </summary>
    public Guid PlcTypeId { get; protected set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; protected set; }

    /// <summary>
    /// Gets the address identifier.
    /// </summary>
    public Guid AddressId { get; protected set; }

    /// <summary>
    /// Gets the machine temperature.
    /// </summary>
    public decimal Temperature { get; protected set; }

    /// <summary>
    /// Gets the job order.
    /// </summary>
    public string? JobOrder { get; protected set; }

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? CustomerEntity { get; protected set; }

    /// <summary>
    /// Gets the associated machine builder.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual MachineBuilder? MachineBuilder { get; protected set; }

    /// <summary>
    /// Gets the associated machine type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual MachineType? MachineType { get; protected set; }

    /// <summary>
    /// Gets the associated PLC type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PlcType? PlcType { get; protected set; }

    /// <summary>
    /// Gets the machine address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; protected set; }

    /// <summary>
    /// Gets the tickets associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Ticket> Tickets { get; protected set; }
        = new List<Ticket>();

    /// <summary>
    /// Gets the interventions associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Intervention> Interventions { get; protected set; }
        = new List<Intervention>();

    /// <summary>
    /// Gets the shipments associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Shipment> Shipments { get; protected set; }
        = new List<Shipment>();

    /// <summary>
    /// Gets the documents associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; protected set; }
        = new List<Document>();

    /// <summary>
    /// Gets the ticket status entries associated with this machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketStatus> TicketStatuses { get; protected set; }
        = new List<TicketStatus>();
}
