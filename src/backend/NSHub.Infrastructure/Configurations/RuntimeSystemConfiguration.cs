// <copyright file="RuntimeSystemConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class RuntimeSystemConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<RuntimeSystem>
{
    public void Configure(EntityTypeBuilder<RuntimeSystem> builder)
    {
        _ = builder.ToTable("RuntimeSystem", "dbo");

        _ = builder.Property(e => e.ConnectionStatus).IsRequired();
        _ = builder.Property(e => e.ConnectionAddress).IsRequired(false);
        _ = builder.Property(e => e.GatewayAddress).IsRequired(false);
        _ = builder.Property(e => e.GatewayPort).IsRequired();
        _ = builder.Property(e => e.CncConfig).IsRequired();
        _ = builder.Property(e => e.CncFbName).IsRequired(false);
        _ = builder.Property(e => e.FbPlcName).IsRequired(false);
        _ = builder.Property(e => e.CncAddress).IsRequired();
        _ = builder.Property(e => e.VersionRts).IsRequired(false);
        _ = builder.Property(e => e.MasterNcAddress).IsRequired();
        _ = builder.Property(e => e.WriteBootInteraction).IsRequired();
        _ = builder.Property(e => e.CncDeviceVersion).IsRequired(false);
        _ = builder.Property(e => e.AffairNumber).IsRequired();
        _ = builder.Property(e => e.IsCycleCom).IsRequired();
        _ = builder.Property(e => e.ServerReinitializationFailed).IsRequired();
        _ = builder.Property(e => e.ScanNetwork).IsRequired();
        _ = builder.Property(e => e.CncIndex).IsRequired();
        _ = builder.Property(e => e.SchedulerType).IsRequired(false);
        _ = builder.Property(e => e.CompatibleNckFirmwareVersion).IsRequired(false);
        _ = builder.Property(e => e.WriteBootInteractionPassword).IsRequired();
        _ = builder.Property(e => e.ServerInitializationFinished).IsRequired();
        _ = builder.Property(e => e.ApplicationConfig).IsRequired();
        _ = builder.Property(e => e.ConnectionType).IsRequired(false);
        _ = builder.Property(e => e.AcknowledgeError2007).IsRequired();
        _ = builder.Property(e => e.NumberOfCnc).IsRequired();
        _ = builder.Property(e => e.IsHasSymbols).IsRequired();
        _ = builder.Property(e => e.IsOptionExtendedNckAccess).IsRequired();
        _ = builder.Property(e => e.IsOptionCanInterface1).IsRequired();
        _ = builder.Property(e => e.IsOptionCanInterface2).IsRequired();
        _ = builder.Property(e => e.IsRtsDemoMode).IsRequired();
        _ = builder.Property(e => e.IsOptionMultiNck).IsRequired();
        _ = builder.Property(e => e.IsOptionTargetVisu).IsRequired();
        _ = builder.Property(e => e.IsOptionWebVisu).IsRequired();
        _ = builder.Property(e => e.IsOptionRemoteVisuClient).IsRequired();
        _ = builder.Property(e => e.IsOptionProfibusMaster).IsRequired();
        _ = builder.Property(e => e.IsOption3RdPartyPc).IsRequired();
        _ = builder.Property(e => e.IsOptionSafetyPlc).IsRequired();
        _ = builder.Property(e => e.IsOptionEl6731).IsRequired();
        _ = builder.Property(e => e.IsOptionPlcToolMgr).IsRequired();
        _ = builder.Property(e => e.IsOptionEl6631).IsRequired();
        _ = builder.Property(e => e.IsOptionOpcUa).IsRequired();
        _ = builder.Property(e => e.PlcLogicPrefix).IsRequired();
        _ = builder.Property(e => e.IoLinkCtmt6224).IsRequired();
        _ = builder.Property(e => e.TimeLimitedEndDate).IsRequired(false);
        _ = builder.Property(e => e.InfoPc).IsRequired(false);
        _ = builder.Property(e => e.IsCncApplicationLoaded).IsRequired();
        _ = builder.Property(e => e.CncApplicationState).IsRequired(false);
        _ = builder.Property(e => e.TargetDeviceName).IsRequired(false);
        _ = builder.Property(e => e.TargetNodeName).IsRequired();
        _ = builder.Property(e => e.TargetNodeAddress).IsRequired(false);
        _ = builder.Property(e => e.TargetVendorName).IsRequired(false);
        _ = builder.Property(e => e.TargetVersion).IsRequired(false);
        _ = builder.Property(e => e.NckPlcState).IsRequired(false);
        _ = builder.Property(e => e.NckPlcOperationsState).IsRequired(false);
        _ = builder.Property(e => e.ExtAddrRtsWaitForUserInteraction).IsRequired(false);
        _ = builder.Property(e => e.RtsWaitForUserInteraction).IsRequired(false);
        _ = builder.Property(e => e.ExtStringDataRtsWaitForUserInteraction).IsRequired(false);
        _ = builder.Property(e => e.RtsWaitForPasswordInput).IsRequired(false);
        _ = builder.Property(e => e.NckNrRtsWaitForUserInteraction).IsRequired(false);
        _ = builder.Property(e => e.RtsWaitForUserInteractionQuestionType).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
