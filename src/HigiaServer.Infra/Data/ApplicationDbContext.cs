using HigiaServer.Domain.Common;
using HigiaServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HigiaServer.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<BaseUserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mappings.BaseUserMap());
        modelBuilder.ApplyConfiguration(new Mappings.TaskMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=application.db;Cache=Shared");
        base.OnConfiguring(optionsBuilder);
    }
}
