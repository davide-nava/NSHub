// <copyright file="RuntimeSystem.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a runtime system configuration and connectivity settings.
/// </summary>
public class RuntimeSystem : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the current connection status.
    /// </summary>
    public int ConnectionStatus { get; set; }

    /// <summary>
    /// Gets or sets the network address used to establish the connection.
    /// </summary>
    public string? ConnectionAddress { get; set; }

    /// <summary>
    /// Gets or sets the gateway network address.
    /// </summary>
    public string? GatewayAddress { get; set; }

    /// <summary>
    /// Gets or sets the communication port of the gateway.
    /// </summary>
    public int GatewayPort { get; set; }

    /// <summary>
    /// Gets or sets the CNC configuration identifier.
    /// </summary>
    public int CncConfig { get; set; }

    /// <summary>
    /// Gets or sets the name of the CNC function block.
    /// </summary>
    public string? CncFbName { get; set; }

    /// <summary>
    /// Gets or sets the name of the PLC function block.
    /// </summary>
    public string? FbPlcName { get; set; }

    /// <summary>
    /// Gets or sets the CNC network address.
    /// </summary>
    public int CncAddress { get; set; }

    /// <summary>
    /// Gets or sets the RTS version.
    /// </summary>
    public string? VersionRts { get; set; }

    /// <summary>
    /// Gets or sets the address of the master NC.
    /// </summary>
    public int MasterNcAddress { get; set; }

    /// <summary>
    /// Gets or sets the write boot interaction status.
    /// </summary>
    public int WriteBootInteraction { get; set; }

    /// <summary>
    /// Gets or sets the CNC device version.
    /// </summary>
    public string? CncDeviceVersion { get; set; }

    /// <summary>
    /// Gets or sets the affair number.
    /// </summary>
    public int AffairNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cyclic communication is enabled.
    /// </summary>
    public bool IsCycleCom { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether server reinitialization has failed.
    /// </summary>
    public bool ServerReinitializationFailed { get; set; }

    /// <summary>
    /// Gets or sets the network scan status.
    /// </summary>
    public int ScanNetwork { get; set; }

    /// <summary>
    /// Gets or sets the CNC index.
    /// </summary>
    public int CncIndex { get; set; }

    /// <summary>
    /// Gets or sets the scheduler type.
    /// </summary>
    public string? SchedulerType { get; set; }

    /// <summary>
    /// Gets or sets the compatible NCK firmware version.
    /// </summary>
    public string? CompatibleNckFirmwareVersion { get; set; }

    /// <summary>
    /// Gets or sets the password required for write boot interaction.
    /// </summary>
    public int WriteBootInteractionPassword { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether server initialization has finished.
    /// </summary>
    public int ServerInitializationFinished { get; set; }

    /// <summary>
    /// Gets or sets the application configuration identifier.
    /// </summary>
    public int ApplicationConfig { get; set; }

    /// <summary>
    /// Gets or sets the connection type.
    /// </summary>
    public string? ConnectionType { get; set; }

    /// <summary>
    /// Gets or sets the acknowledgement status for error 2007.
    /// </summary>
    public int AcknowledgeError2007 { get; set; }

    /// <summary>
    /// Gets or sets the number of CNC systems.
    /// </summary>
    public int NumberOfCnc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether symbol information is available.
    /// </summary>
    public bool IsHasSymbols { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Extended NCK Access option is enabled.
    /// </summary>
    public bool IsOptionExtendedNckAccess { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether CAN Interface 1 is enabled.
    /// </summary>
    public bool IsOptionCanInterface1 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether CAN Interface 2 is enabled.
    /// </summary>
    public bool IsOptionCanInterface2 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether RTS demo mode is enabled.
    /// </summary>
    public bool IsRtsDemoMode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Multi-NCK option is enabled.
    /// </summary>
    public bool IsOptionMultiNck { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Target Visualization option is enabled.
    /// </summary>
    public bool IsOptionTargetVisu { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Web Visualization option is enabled.
    /// </summary>
    public bool IsOptionWebVisu { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Remote Visualization Client option is enabled.
    /// </summary>
    public bool IsOptionRemoteVisuClient { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Profibus Master option is enabled.
    /// </summary>
    public bool IsOptionProfibusMaster { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the third-party PC option is enabled.
    /// </summary>
    public bool IsOption3RdPartyPc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Safety PLC option is enabled.
    /// </summary>
    public bool IsOptionSafetyPlc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the EL6731 option is enabled.
    /// </summary>
    public bool IsOptionEl6731 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the PLC Tool Manager option is enabled.
    /// </summary>
    public bool IsOptionPlcToolMgr { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the EL6631 option is enabled.
    /// </summary>
    public bool IsOptionEl6631 { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the OPC UA option is enabled.
    /// </summary>
    public bool IsOptionOpcUa { get; set; }

    /// <summary>
    /// Gets or sets the PLC logic prefix.
    /// </summary>
    public int PlcLogicPrefix { get; set; }

    /// <summary>
    /// Gets or sets the IO-Link CTMT6224 configuration value.
    /// </summary>
    public int IoLinkCtmt6224 { get; set; }

    /// <summary>
    /// Gets or sets the end date of the time-limited licence.
    /// </summary>
    public string? TimeLimitedEndDate { get; set; }

    /// <summary>
    /// Gets or sets information about the PC.
    /// </summary>
    public string? InfoPc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the CNC application is loaded.
    /// </summary>
    public bool IsCncApplicationLoaded { get; set; }

    /// <summary>
    /// Gets or sets the CNC application state.
    /// </summary>
    public string? CncApplicationState { get; set; }

    /// <summary>
    /// Gets or sets the target device name.
    /// </summary>
    public string? TargetDeviceName { get; set; }

    /// <summary>
    /// Gets or sets the target node name.
    /// </summary>
    public string TargetNodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the target node address.
    /// </summary>
    public string? TargetNodeAddress { get; set; }

    /// <summary>
    /// Gets or sets the target vendor name.
    /// </summary>
    public string? TargetVendorName { get; set; }

    /// <summary>
    /// Gets or sets the target version.
    /// </summary>
    public string? TargetVersion { get; set; }

    /// <summary>
    /// Gets or sets the NCK PLC state.
    /// </summary>
    public string? NckPlcState { get; set; }

    /// <summary>
    /// Gets or sets the NCK PLC operation state.
    /// </summary>
    public string? NckPlcOperationsState { get; set; }

    /// <summary>
    /// Gets or sets the external RTS user interaction address.
    /// </summary>
    public string? ExtAddrRtsWaitForUserInteraction { get; set; }

    /// <summary>
    /// Gets or sets the RTS user interaction state.
    /// </summary>
    public string? RtsWaitForUserInteraction { get; set; }

    /// <summary>
    /// Gets or sets additional RTS user interaction data.
    /// </summary>
    public string? ExtStringDataRtsWaitForUserInteraction { get; set; }

    /// <summary>
    /// Gets or sets the RTS password input request status.
    /// </summary>
    public string? RtsWaitForPasswordInput { get; set; }

    /// <summary>
    /// Gets or sets the NCK number related to RTS user interaction.
    /// </summary>
    public string? NckNrRtsWaitForUserInteraction { get; set; }

    /// <summary>
    /// Gets or sets the RTS user interaction question type.
    /// </summary>
    public string? RtsWaitForUserInteractionQuestionType { get; set; }
}
