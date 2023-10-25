﻿using HigiaServer.Domain.Common;
using HigiaServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Infra.Data.Mappings;

public class TaskMap : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("task")
            .HasMany(x => x.Collaborators)
            .WithMany(x => x.Tasks)
            .UsingEntity<Dictionary<string, object>>(
                "task_user",
                x => x.HasOne<Collaborator>().WithMany().HasForeignKey("user_id"),
                x => x.HasOne<Domain.Entities.Task>().WithMany().HasForeignKey("task_id"),
                x => x.HasKey("user_id", "task_id")
            );

        builder.HasIndex(x => x.Id)
            .IsUnique();

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.InitialCoordinate)
            .HasColumnName("initial_coordinate")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();

        builder.Property(x => x.EndCoordinate)
            .HasColumnName("final_coordinate")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.LastModifiedAt)
            .HasColumnName("last_modified_at")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("created_by")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.LastModifiedBy)
            .HasColumnName("last_modified_by")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();

        builder.Property(x => x.Observation)
            .HasColumnName("observation")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();
        
        builder.Property(x => x.InitialCoordinate)
            .HasColumnName("initial_coordinate")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();

        builder.Property(x => x.ExpectedEndTime)
            .HasColumnName("expected_end_time")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.EndCoordinate)
            .HasColumnName("final_coordinate")
            .HasColumnType("NVARCHAR(255)")
            .IsRequired();

        builder.Property(x => x.EndTime)
            .HasColumnName("end_time")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.StartTime)
            .HasColumnName("start_time")
            .HasColumnType("TIMESTAMP")
            .IsRequired();
    }   
}