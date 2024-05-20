using HigiaServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Infra.DbContext;

public class HigiaServerContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<RecordTask> RecordTasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseInMemoryDatabase(databaseName: "HigiaServerDb");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User(
            isAdmin: true,
            name: "admin",
            email: "admin@admin.com",
            password: "adminadmin"
        ));
    }
}
