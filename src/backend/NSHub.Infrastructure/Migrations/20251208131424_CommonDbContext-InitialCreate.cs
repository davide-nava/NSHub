// <copyright file="20251208131424_CommonDbContext-InitialCreate.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSHub.Infrastructure.Migrations;

/// <inheritdoc />
public partial class NSHubDbContextInitialCreate : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		ArgumentNullException.ThrowIfNull(migrationBuilder);
        _ = migrationBuilder.CreateTable(
            name: "AccessLog",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Result = table.Column<bool>(type: "bit", nullable: false),
                Log = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserUpdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserInsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DtUdp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                DtIns = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                DtDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
            },
            constraints: table => table.PrimaryKey("PK_AccessLog", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Language",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserUpdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserInsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DtUdp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                DtIns = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                DtDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
            },
            constraints: table => table.PrimaryKey("PK_Language", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Notification",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                NotificationType = table.Column<int>(type: "int", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserUpdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserInsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DtUdp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                DtIns = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                DtDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
            },
            constraints: table => table.PrimaryKey("PK_Notification", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Setting",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Encrypted = table.Column<bool>(type: "bit", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserUpdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserInsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DtUdp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                DtIns = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                DtDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
            },
            constraints: table => table.PrimaryKey("PK_Setting", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Tenant",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserUpdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserInsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DtUdp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                DtIns = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                DtDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
            },
            constraints: table => table.PrimaryKey("PK_Tenant", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserUpdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                UserInsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DtUdp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                DtIns = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                DtDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                Configuration = table.Column<string>(type: "json", nullable: false),
            },
            constraints: table => table.PrimaryKey("PK_User", x => x.Id));

        _ = migrationBuilder.CreateIndex(
            name: "IX_AccessLog_IsDeleted",
            table: "AccessLog",
            column: "IsDeleted",
            filter: "IsDeleted = 0");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Language_IsDeleted",
            table: "Language",
            column: "IsDeleted",
            filter: "IsDeleted = 0");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Notification_IsDeleted",
            table: "Notification",
            column: "IsDeleted",
            filter: "IsDeleted = 0");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Setting_IsDeleted",
            table: "Setting",
            column: "IsDeleted",
            filter: "IsDeleted = 0");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Tenant_IsDeleted",
            table: "Tenant",
            column: "IsDeleted",
            filter: "IsDeleted = 0");

        _ = migrationBuilder.CreateIndex(
            name: "IX_User_IsDeleted",
            table: "User",
            column: "IsDeleted",
            filter: "IsDeleted = 0");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		ArgumentNullException.ThrowIfNull(migrationBuilder);
        _ = migrationBuilder.DropTable(
            name: "AccessLog");

        _ = migrationBuilder.DropTable(
            name: "Language");

        _ = migrationBuilder.DropTable(
            name: "Notification");

        _ = migrationBuilder.DropTable(
            name: "Setting");

        _ = migrationBuilder.DropTable(
            name: "Tenant");

        _ = migrationBuilder.DropTable(
            name: "User");
	}
}
