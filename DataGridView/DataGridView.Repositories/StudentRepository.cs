using DataGridView.Context;
using DataGridView.Entities;
using DataGridView.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.Repositories;

/// <summary>
/// Репозиторий для доступа к студентам
/// </summary>
//public class StudentRepository(StudentContext<IStudentEntityConfiguration> context) : IStorage
public class StudentRepository(StudentContext context) : IStorage
{
    public async Task Add(Student student, CancellationToken cancellationToken)
    {
        context.Add(student);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Remove(Student student, CancellationToken cancellationToken)
    {
        context.Remove(student);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Student student, CancellationToken cancellationToken)
    {
        context.Update(student);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Student?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Student>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Student>> GetAll(CancellationToken cancellationToken)
    {
        return await context.Set<Student>().ToListAsync(cancellationToken);
    }

    public async Task<int> GetCount(CancellationToken cancellationToken)
    {
        return await context.Set<Student>().CountAsync(cancellationToken);
    }
}