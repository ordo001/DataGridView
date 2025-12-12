using DataGridView.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.Context;

/// <summary>
/// Контекст базы данных для студентов
/// </summary>
public class StudentContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StudentDb;Username=postgres;Password=postgres");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>()
            .HasKey(x => x.Id);
    }
}