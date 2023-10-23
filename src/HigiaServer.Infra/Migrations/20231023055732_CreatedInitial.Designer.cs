﻿// <auto-generated />
using System;
using HigiaServer.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HigiaServer.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231023055732_CreatedInitial")]
    partial class CreatedInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("HigiaServer.Domain.Common.BaseUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);

                    b.HasDiscriminator<bool>("IsAdmin");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HigiaServer.Domain.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndCoordinate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("ExpectedEndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("InitialCoordinate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("InitialTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastModifiedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observation")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("task", (string)null);
                });

            modelBuilder.Entity("task_user", b =>
                {
                    b.Property<Guid>("user_id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("task_id")
                        .HasColumnType("TEXT");

                    b.HasKey("user_id", "task_id");

                    b.HasIndex("task_id");

                    b.ToTable("task_user");
                });

            modelBuilder.Entity("HigiaServer.Domain.Entities.Administrator", b =>
                {
                    b.HasBaseType("HigiaServer.Domain.Common.BaseUserEntity");

                    b.HasDiscriminator().HasValue(true);
                });

            modelBuilder.Entity("HigiaServer.Domain.Entities.Collaborator", b =>
                {
                    b.HasBaseType("HigiaServer.Domain.Common.BaseUserEntity");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastModifiedById")
                        .HasColumnType("TEXT");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasDiscriminator().HasValue(false);
                });

            modelBuilder.Entity("HigiaServer.Domain.Entities.Task", b =>
                {
                    b.HasOne("HigiaServer.Domain.Entities.Administrator", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("HigiaServer.Domain.Entities.Administrator", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("task_user", b =>
                {
                    b.HasOne("HigiaServer.Domain.Entities.Task", null)
                        .WithMany()
                        .HasForeignKey("task_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HigiaServer.Domain.Entities.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HigiaServer.Domain.Entities.Collaborator", b =>
                {
                    b.HasOne("HigiaServer.Domain.Entities.Administrator", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("HigiaServer.Domain.Entities.Administrator", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
