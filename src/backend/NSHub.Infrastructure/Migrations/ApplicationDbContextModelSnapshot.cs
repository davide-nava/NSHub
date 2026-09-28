// <copyright file="ApplicationDbContextModelSnapshot.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NSHub.Infrastructure.DbContexts;

#nullable disable

namespace NSHub.Infrastructure.Migrations;

/// <summary>
/// Entity Framework model snapshot for the application database context.
/// </summary>
[DbContext(typeof(ApplicationDbContext))]
public class ApplicationDbContextModelSnapshot : ModelSnapshot
{
    /// <summary>
    /// Builds the relational database model for this context.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        _ = modelBuilder
            .HasAnnotation("ProductVersion", "10.0.0")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        _ = modelBuilder.UseIdentityColumns();

        _ = modelBuilder.Entity("NSHub.Application.Models.ApplicationUser", b =>
            {
                _ = b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                _ = b.Property<int>("AccessFailedCount")
                    .HasColumnType("int");

                _ = b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("Email")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.Property<bool>("EmailConfirmed")
                    .HasColumnType("bit");

                _ = b.Property<bool>("LockoutEnabled")
                    .HasColumnType("bit");

                _ = b.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("datetimeoffset");

                _ = b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.Property<string>("PasswordHash")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("PhoneNumber")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("bit");

                _ = b.Property<string>("SecurityStamp")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("bit");

                _ = b.Property<string>("UserName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.HasKey("Id");

                _ = b.HasIndex("NormalizedEmail")
                    .HasDatabaseName("EmailIndex");

                _ = b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasDatabaseName("UserNameIndex")
                    .HasFilter("[NormalizedUserName] IS NOT NULL");

                _ = b.ToTable("AspNetUsers", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                _ = b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                _ = b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("Name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.Property<string>("NormalizedName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                _ = b.HasKey("Id");

                _ = b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasDatabaseName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                _ = b.ToTable("AspNetRoles", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                _ = b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                _ = b.Property<int>("Id").UseIdentityColumn();

                _ = b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("RoleId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                _ = b.HasKey("Id");

                _ = b.HasIndex("RoleId");

                _ = b.ToTable("AspNetRoleClaims", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                _ = b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                _ = b.Property<int>("Id").UseIdentityColumn();

                _ = b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                _ = b.HasKey("Id");

                _ = b.HasIndex("UserId");

                _ = b.ToTable("AspNetUserClaims", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                _ = b.Property<string>("LoginProvider")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                _ = b.Property<string>("ProviderKey")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                _ = b.Property<string>("ProviderDisplayName")
                    .HasColumnType("nvarchar(max)");

                _ = b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                _ = b.HasKey("LoginProvider", "ProviderKey");

                _ = b.HasIndex("UserId");

                _ = b.ToTable("AspNetUserLogins", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserPasskey<string>", b =>
            {
                _ = b.Property<byte[]>("CredentialId")
                    .HasMaxLength(1024)
                    .HasColumnType("varbinary(1024)");

                _ = b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                _ = b.HasKey("CredentialId");

                _ = b.HasIndex("UserId");

                _ = b.ToTable("AspNetUserPasskeys", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                _ = b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                _ = b.Property<string>("RoleId")
                    .HasColumnType("nvarchar(450)");

                _ = b.HasKey("UserId", "RoleId");

                _ = b.HasIndex("RoleId");

                _ = b.ToTable("AspNetUserRoles", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                _ = b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                _ = b.Property<string>("LoginProvider")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                _ = b.Property<string>("Name")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                _ = b.Property<string>("Value")
                    .HasColumnType("nvarchar(max)");

                _ = b.HasKey("UserId", "LoginProvider", "Name");

                _ = b.ToTable("AspNetUserTokens", (string)null);
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b => b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired());

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b => b.HasOne("NSHub.Application.Models.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired());

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b => b.HasOne("NSHub.Application.Models.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired());

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserPasskey<string>", b =>
            {
                _ = b.HasOne("NSHub.Application.Models.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                _ = b.OwnsOne("Microsoft.AspNetCore.Identity.IdentityPasskeyData", "Data", b1 =>
                    {
                        _ = b1.Property<byte[]>("IdentityUserPasskeyCredentialId")
                            .HasColumnType("varbinary(1024)");

                        _ = b1.Property<byte[]>("AttestationObject")
                            .IsRequired()
                            .HasColumnType("varbinary(max)");

                        _ = b1.Property<byte[]>("ClientDataJson")
                            .IsRequired()
                            .HasColumnType("varbinary(max)");

                        _ = b1.Property<DateTimeOffset>("CreatedAt")
                            .HasColumnType("datetimeoffset");

                        _ = b1.Property<bool>("IsBackedUp")
                            .HasColumnType("bit");

                        _ = b1.Property<bool>("IsBackupEligible")
                            .HasColumnType("bit");

                        _ = b1.Property<bool>("IsUserVerified")
                            .HasColumnType("bit");

                        _ = b1.Property<string>("Name")
                            .HasColumnType("nvarchar(max)");

                        _ = b1.Property<byte[]>("PublicKey")
                            .IsRequired()
                            .HasColumnType("varbinary(max)");

                        _ = b1.Property<long>("SignCount")
                            .HasColumnType("bigint");

                        _ = b1.PrimitiveCollection<string>("Transports")
                            .HasColumnType("nvarchar(max)");

                        _ = b1.HasKey("IdentityUserPasskeyCredentialId");

                        _ = b1.ToTable("AspNetUserPasskeys");

                        _ = b1.ToJson("Data");

                        _ = b1.WithOwner()
                            .HasForeignKey("IdentityUserPasskeyCredentialId");
                    });

                _ = b.Navigation("Data")
                    .IsRequired();
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                _ = b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                _ = b.HasOne("NSHub.Application.Models.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        _ = modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b => b.HasOne("NSHub.Application.Models.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired());
#pragma warning restore 612, 618
    }
}
