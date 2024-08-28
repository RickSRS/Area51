using HealthCheck.Model;
using Microsoft.EntityFrameworkCore;

namespace HealthCheck.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserModel>()
            .HasIndex(user => user.Email)
            .IsUnique();
    }
}