// <copyright file="RuntimeSystemConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class RuntimeSystemConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<RuntimeSystem>
{
    public void Configure(EntityTypeBuilder<RuntimeSystem> builder)
    {
        builder.ToTable("RuntimeSystem", "dbo");


        builder.Property(e => e.ConnectionStatus).IsRequired();
        builder.Property(e => e.ConnectionAddress).IsRequired(false);
        builder.Property(e => e.GatewayAddress).IsRequired(false);
        builder.Property(e => e.GatewayPort).IsRequired();
        builder.Property(e => e.CncConfig).IsRequired();
        builder.Property(e => e.CncFbName).IsRequired(false);
        builder.Property(e => e.FbPlcName).IsRequired(false);
        builder.Property(e => e.CncAddress).IsRequired();
        builder.Property(e => e.VersionRts).IsRequired(false);
        builder.Property(e => e.MasterNcAddress).IsRequired();
        builder.Property(e => e.WriteBootInteraction).IsRequired();
        builder.Property(e => e.CncDeviceVersion).IsRequired(false);
        builder.Property(e => e.AffairNumber).IsRequired();
        builder.Property(e => e.IsCycleCom).IsRequired();
        builder.Property(e => e.ServerReinitializationFailed).IsRequired();
        builder.Property(e => e.ScanNetwork).IsRequired();
        builder.Property(e => e.CncIndex).IsRequired();
        builder.Property(e => e.SchedulerType).IsRequired(false);
        builder.Property(e => e.CompatibleNckFirmwareVersion).IsRequired(false);
        builder.Property(e => e.WriteBootInteractionPassword).IsRequired();
        builder.Property(e => e.ServerInitializationFinished).IsRequired();
        builder.Property(e => e.ApplicationConfig).IsRequired();
        builder.Property(e => e.ConnectionType).IsRequired(false);
        builder.Property(e => e.AcknowledgeError2007).IsRequired();
        builder.Property(e => e.NumberOfCnc).IsRequired();
        builder.Property(e => e.IsHasSymbols).IsRequired();
        builder.Property(e => e.IsOptionExtendedNckAccess).IsRequired();
        builder.Property(e => e.IsOptionCanInterface1).IsRequired();
        builder.Property(e => e.IsOptionCanInterface2).IsRequired();
        builder.Property(e => e.IsRtsDemoMode).IsRequired();
        builder.Property(e => e.IsOptionMultiNck).IsRequired();
        builder.Property(e => e.IsOptionTargetVisu).IsRequired();
        builder.Property(e => e.IsOptionWebVisu).IsRequired();
        builder.Property(e => e.IsOptionRemoteVisuClient).IsRequired();
        builder.Property(e => e.IsOptionProfibusMaster).IsRequired();
        builder.Property(e => e.IsOption3RdPartyPc).IsRequired();
        builder.Property(e => e.IsOptionSafetyPlc).IsRequired();
        builder.Property(e => e.IsOptionEl6731).IsRequired();
        builder.Property(e => e.IsOptionPlcToolMgr).IsRequired();
        builder.Property(e => e.IsOptionEl6631).IsRequired();
        builder.Property(e => e.IsOptionOpcUa).IsRequired();
        builder.Property(e => e.PlcLogicPrefix).IsRequired();
        builder.Property(e => e.IoLinkCtmt6224).IsRequired();
        builder.Property(e => e.TimeLimitedEndDate).IsRequired(false);
        builder.Property(e => e.InfoPc).IsRequired(false);
        builder.Property(e => e.IsCncApplicationLoaded).IsRequired();
        builder.Property(e => e.CncApplicationState).IsRequired(false);
        builder.Property(e => e.TargetDeviceName).IsRequired(false);
        builder.Property(e => e.TargetNodeName).IsRequired();
        builder.Property(e => e.TargetNodeAddress).IsRequired(false);
        builder.Property(e => e.TargetVendorName).IsRequired(false);
        builder.Property(e => e.TargetVersion).IsRequired(false);
        builder.Property(e => e.NckPlcState).IsRequired(false);
        builder.Property(e => e.NckPlcOperationsState).IsRequired(false);
        builder.Property(e => e.ExtAddrRtsWaitForUserInteraction).IsRequired(false);
        builder.Property(e => e.RtsWaitForUserInteraction).IsRequired(false);
        builder.Property(e => e.ExtStringDataRtsWaitForUserInteraction).IsRequired(false);
        builder.Property(e => e.RtsWaitForPasswordInput).IsRequired(false);
        builder.Property(e => e.NckNrRtsWaitForUserInteraction).IsRequired(false);
        builder.Property(e => e.RtsWaitForUserInteractionQuestionType).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
