using HigiaServer.Infra.Data.Mappings;

namespace HigiaServer.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<BaseUserEntity> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BaseUserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
    }
}