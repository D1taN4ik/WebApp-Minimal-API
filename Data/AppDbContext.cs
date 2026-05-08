using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Инициализация тестовыми данными (минимум 3 записи)
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", Age = 37, Email = "tom@example.com" },
            new User { Id = 2, Name = "Bob", Age = 41, Email = "bob@example.com" },
            new User { Id = 3, Name = "Alice", Age = 29, Email = "alice@example.com" }
        );
    }
}