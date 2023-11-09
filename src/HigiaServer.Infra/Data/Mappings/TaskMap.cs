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
                x => x.HasOne<Task>().WithMany().HasForeignKey("task_id"),
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