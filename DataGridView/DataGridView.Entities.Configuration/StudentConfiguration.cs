using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataGridView.Entities.Configuration;

/// <summary>
/// Конфигурация для <see cref="Student"/>
/// </summary>
public class StudentConfiguration : IEntityTypeConfiguration<Student>, IStudentEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        
        builder.HasKey(x => x.Id);
    }
}