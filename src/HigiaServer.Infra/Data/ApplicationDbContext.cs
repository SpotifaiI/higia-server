using HigiaServer.Infra.Data.Mappings;

namespace HigiaServer.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<BaseUserEntity> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BaseUserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=application.db;Cache=Shared");
        base.OnConfiguring(optionsBuilder);
    }
}