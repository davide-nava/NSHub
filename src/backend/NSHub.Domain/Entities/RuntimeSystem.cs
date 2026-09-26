// <copyright file="RuntimeSystem.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class RuntimeSystem : AuditableTenantEntity
{
    public int ConnectionStatus { get; protected set; }
    public string? ConnectionAddress { get; protected set; }
    public string? GatewayAddress { get; protected set; }
    public int GatewayPort { get; protected set; }
    public int CncConfig { get; protected set; }
    public string? CncFbName { get; protected set; }
    public string? FbPlcName { get; protected set; }
    public int CncAddress { get; protected set; }
    public string? VersionRts { get; protected set; }
    public int MasterNcAddress { get; protected set; }
    public int WriteBootInteraction { get; protected set; }
    public string? CncDeviceVersion { get; protected set; }
    public int AffairNumber { get; protected set; }
    public bool IsCycleCom { get; protected set; }
    public bool ServerReinitializationFailed { get; protected set; }
    public int ScanNetwork { get; protected set; }
    public int CncIndex { get; protected set; }
    public string? SchedulerType { get; protected set; }
    public string? CompatibleNckFirmwareVersion { get; protected set; }
    public int WriteBootInteractionPassword { get; protected set; }
    public int ServerInitializationFinished { get; protected set; }
    public int ApplicationConfig { get; protected set; }
    public string? ConnectionType { get; protected set; }
    public int AcknowledgeError2007 { get; protected set; }
    public int NumberOfCnc { get; protected set; }
    public bool IsHasSymbols { get; protected set; }
    public bool IsOptionExtendedNckAccess { get; protected set; }
    public bool IsOptionCanInterface1 { get; protected set; }
    public bool IsOptionCanInterface2 { get; protected set; }
    public bool IsRtsDemoMode { get; protected set; }
    public bool IsOptionMultiNck { get; protected set; }
    public bool IsOptionTargetVisu { get; protected set; }
    public bool IsOptionWebVisu { get; protected set; }
    public bool IsOptionRemoteVisuClient { get; protected set; }
    public bool IsOptionProfibusMaster { get; protected set; }
    public bool IsOption3RdPartyPc { get; protected set; }
    public bool IsOptionSafetyPlc { get; protected set; }
    public bool IsOptionEl6731 { get; protected set; }
    public bool IsOptionPlcToolMgr { get; protected set; }
    public bool IsOptionEl6631 { get; protected set; }
    public bool IsOptionOpcUa { get; protected set; }
    public int PlcLogicPrefix { get; protected set; }
    public int IoLinkCtmt6224 { get; protected set; }
    public string? TimeLimitedEndDate { get; protected set; }
    public string? InfoPc { get; protected set; }
    public bool IsCncApplicationLoaded { get; protected set; }
    public string? CncApplicationState { get; protected set; }
    public string? TargetDeviceName { get; protected set; }
    public string TargetNodeName { get; protected set; } = string.Empty;
    public string? TargetNodeAddress { get; protected set; }
    public string? TargetVendorName { get; protected set; }
    public string? TargetVersion { get; protected set; }
    public string? NckPlcState { get; protected set; }
    public string? NckPlcOperationsState { get; protected set; }
    public string? ExtAddrRtsWaitForUserInteraction { get; protected set; }
    public string? RtsWaitForUserInteraction { get; protected set; }
    public string? ExtStringDataRtsWaitForUserInteraction { get; protected set; }
    public string? RtsWaitForPasswordInput { get; protected set; }
    public string? NckNrRtsWaitForUserInteraction { get; protected set; }
    public string? RtsWaitForUserInteractionQuestionType { get; protected set; }

    protected RuntimeSystem() { }

    public static RuntimeSystem Create()
    {
        return new RuntimeSystem();
    }
}
