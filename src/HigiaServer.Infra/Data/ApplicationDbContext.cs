using HigiaServer.Domain.Common;
using HigiaServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HigiaServer.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<BaseUserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseUserEntity>()
            .ToTable("user")
            .HasDiscriminator<bool>(x => x.IsAdmin)
            .HasValue<Collaborator>(false)
            .HasValue<Administrator>(true);

        modelBuilder.Entity<Domain.Entities.Task>()
            .ToTable("task")
            .HasMany(x => x.Collaborators)
            .WithMany(x => x.Tasks)
            .UsingEntity<Dictionary<string, object>>(
                "task_user",
                x => x.HasOne<Collaborator>().WithMany().HasForeignKey("user_id"),
                x => x.HasOne<Domain.Entities.Task>().WithMany().HasForeignKey("task_id"),
                x => x.HasKey("user_id", "task_id")
            );

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=application.db;Cache=Shared");
        base.OnConfiguring(optionsBuilder);
    }
}
