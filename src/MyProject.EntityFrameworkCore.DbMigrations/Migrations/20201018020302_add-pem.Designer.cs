﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.Migrations
{
    [DbContext(typeof(MyProjectMigrationsDbContext))]
    [Migration("20201018020302_add-pem")]
    partial class addpem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.SqlServer)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyProject.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnName("DeleterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDeleted")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnName("LastModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("MyProject.UserRoles.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("MyProject.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnName("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnName("DeleterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDeleted")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnName("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnName("LastModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .HasName("ID_User_UserName");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationName")
                        .HasColumnName("ApplicationName")
                        .HasColumnType("nvarchar(96)")
                        .HasMaxLength(96);

                    b.Property<string>("BrowserInfo")
                        .HasColumnName("BrowserInfo")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("ClientId")
                        .HasColumnName("ClientId")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ClientIpAddress")
                        .HasColumnName("ClientIpAddress")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ClientName")
                        .HasColumnName("ClientName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Comments")
                        .HasColumnName("Comments")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("ConcurrencyStamp")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("CorrelationId")
                        .HasColumnName("CorrelationId")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Exceptions")
                        .HasColumnName("Exceptions")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("ExecutionDuration")
                        .HasColumnName("ExecutionDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtraProperties")
                        .HasColumnName("ExtraProperties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HttpMethod")
                        .HasColumnName("HttpMethod")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<int?>("HttpStatusCode")
                        .HasColumnName("HttpStatusCode")
                        .HasColumnType("int");

                    b.Property<Guid?>("ImpersonatorTenantId")
                        .HasColumnName("ImpersonatorTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ImpersonatorUserId")
                        .HasColumnName("ImpersonatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnName("Url")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<Guid?>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "ExecutionTime");

                    b.HasIndex("TenantId", "UserId", "ExecutionTime");

                    b.ToTable("AbpAuditLogs");
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLogAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditLogId")
                        .HasColumnName("AuditLogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExecutionDuration")
                        .HasColumnName("ExecutionDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnName("ExecutionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtraProperties")
                        .HasColumnName("ExtraProperties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MethodName")
                        .HasColumnName("MethodName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Parameters")
                        .HasColumnName("Parameters")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("ServiceName")
                        .HasColumnName("ServiceName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<Guid?>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuditLogId");

                    b.HasIndex("TenantId", "ServiceName", "MethodName", "ExecutionTime");

                    b.ToTable("AbpAuditLogActions");
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditLogId")
                        .HasColumnName("AuditLogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnName("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("ChangeType")
                        .HasColumnName("ChangeType")
                        .HasColumnType("tinyint");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasColumnName("EntityId")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<Guid?>("EntityTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntityTypeFullName")
                        .IsRequired()
                        .HasColumnName("EntityTypeFullName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ExtraProperties")
                        .HasColumnName("ExtraProperties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuditLogId");

                    b.HasIndex("TenantId", "EntityTypeFullName", "EntityId");

                    b.ToTable("AbpEntityChanges");
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityPropertyChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityChangeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NewValue")
                        .HasColumnName("NewValue")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("OriginalValue")
                        .HasColumnName("OriginalValue")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnName("PropertyName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("PropertyTypeFullName")
                        .IsRequired()
                        .HasColumnName("PropertyTypeFullName")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid?>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EntityChangeId");

                    b.ToTable("AbpEntityPropertyChanges");
                });

            modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionGrant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid?>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Name", "ProviderName", "ProviderKey");

                    b.ToTable("AbpPermissionGrants");
                });

            modelBuilder.Entity("MyProject.UserRoles.UserRole", b =>
                {
                    b.HasOne("MyProject.Roles.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProject.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLogAction", b =>
                {
                    b.HasOne("Volo.Abp.AuditLogging.AuditLog", null)
                        .WithMany("Actions")
                        .HasForeignKey("AuditLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b =>
                {
                    b.HasOne("Volo.Abp.AuditLogging.AuditLog", null)
                        .WithMany("EntityChanges")
                        .HasForeignKey("AuditLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityPropertyChange", b =>
                {
                    b.HasOne("Volo.Abp.AuditLogging.EntityChange", null)
                        .WithMany("PropertyChanges")
                        .HasForeignKey("EntityChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
