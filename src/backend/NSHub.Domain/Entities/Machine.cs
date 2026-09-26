using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Machine : AuditableTenantEntity
{
    public string Notes { get; protected set; } = string.Empty;
    public string Number { get; protected set; } = string.Empty;
    public DateTime WarrantyEndDate { get; protected set; }
    public DateTime AcceptanceDate { get; protected set; }
    public DateTime DeliveryDate { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public string CustomerCode { get; protected set; } = string.Empty;
    public string Customer { get; protected set; } = string.Empty;
    public string Pneumatic { get; protected set; } = string.Empty;
    public string Hydraulic { get; protected set; } = string.Empty;
    public string WorkpieceProbe { get; protected set; } = string.Empty;
    public string WheelProbe { get; protected set; } = string.Empty;
    public string Nakanishi { get; protected set; } = string.Empty;
    public string Hh { get; protected set; } = string.Empty;
    public string TBelt { get; protected set; } = string.Empty;
    public string Clutch { get; protected set; } = string.Empty;
    public string AxisU { get; protected set; } = string.Empty;
    public string SpindleCode { get; protected set; } = string.Empty;
    public string WheelMotorCode { get; protected set; } = string.Empty;
    public string Pc { get; protected set; } = string.Empty;
    public string PcBox { get; protected set; } = string.Empty;
    public string ModuleCode { get; protected set; } = string.Empty;
    public string AxisModules { get; protected set; } = string.Empty;
    public string SafetyMod { get; protected set; } = string.Empty;
    public string Inverters { get; protected set; } = string.Empty;
    public Guid MachineBuilderId { get; protected set; }
    public Guid MachineTypeId { get; protected set; }
    public Guid PlcTypeId { get; protected set; }
    public Guid? CustomerId { get; protected set; }
    public Guid AddressId { get; protected set; }
    public decimal Temperature { get; protected set; }
    public string? JobOrder { get; protected set; }
    public virtual Customer? CustomerEntity { get; protected set; }
    public virtual MachineBuilder? MachineBuilder { get; protected set; }
    public virtual MachineType? MachineType { get; protected set; }
    public virtual PlcType? PlcType { get; protected set; }

    private readonly List<ArticleMachine> _articleMachines = new();
    public virtual IReadOnlyCollection<ArticleMachine> ArticleMachines => _articleMachines.AsReadOnly();
    private readonly List<Intervention> _interventions = new();
    public virtual IReadOnlyCollection<Intervention> Interventions => _interventions.AsReadOnly();
    private readonly List<MachineEvent> _machineEvents = new();
    public virtual IReadOnlyCollection<MachineEvent> MachineEvents => _machineEvents.AsReadOnly();
    private readonly List<Shipment> _shipments = new();
    public virtual IReadOnlyCollection<Shipment> Shipments => _shipments.AsReadOnly();
    private readonly List<Ticket> _tickets = new();
    public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();
    private readonly List<TicketStatus> _ticketStatuses = new();
    public virtual IReadOnlyCollection<TicketStatus> TicketStatuses => _ticketStatuses.AsReadOnly();

    protected Machine() { }

    public static Machine Create()
    {
        return new Machine();
    }
}
