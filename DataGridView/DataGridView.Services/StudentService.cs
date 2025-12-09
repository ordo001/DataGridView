using System.Diagnostics;
using DataGridView.Entities;
using DataGridView.Repositories.Contracts;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace DataGridView.Services;

/// <summary>
/// Сервис по работе со студентами
/// </summary>
public class StudentService : IStudentService
{
    private readonly IStorage storage;
    private readonly ILogger logger;

    /// <summary>
    /// Инициализировать новый экземпляр <see cref="StudentService"/>
    /// </summary>
    public StudentService(IStorage storage, ILoggerFactory loggerFactory)
    {
        this.storage = storage;
        logger = loggerFactory.CreateLogger(nameof(StudentService));
        
        
    }

    public async Task Add(Student student, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            student.BirthDate = student.BirthDate.ToUniversalTime();
            await storage.Add(student, cancellationToken);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation($"Add выполнен за {sw.ElapsedMilliseconds} мс");
        }
    }

    public async Task Remove(Guid id, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var std = await storage.GetById(id, cancellationToken);
            await storage.Remove(std, cancellationToken);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation($"Remove выполнен за {sw.ElapsedMilliseconds} мс");
        }
    }

    public async Task Update(Student student, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var std = await storage.GetById(student.Id, cancellationToken);

            std.BirthDate = student.BirthDate.ToUniversalTime();
            std.Gender = student.Gender;
            std.FormEducation = student.FormEducation;
            std.FullName = student.FullName;
            std.InformaticsScore = student.InformaticsScore;
            std.RussianScore = student.RussianScore;
            std.MathScore = student.MathScore;

            await storage.Update(std, cancellationToken);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation($"Update выполнен за {sw.ElapsedMilliseconds} мс");
        }
    }

    public async Task<ICollection<Student>> GetAll(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            await Task.Delay(1000, cancellationToken);
            return await storage.GetAll(cancellationToken);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation("GetAll выполнен за {SwElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
        }
    }

    public async Task<int> GetStudentsByMinScore(int count, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var stds = await storage.GetAll(cancellationToken);
            return stds.Count(x => x.InformaticsScore + x.MathScore + x.RussianScore > count);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation($"GetStudentsByMinScore выполнен за {sw.ElapsedMilliseconds} мс");
        }
    }

    public async Task<int> GetCountStudents(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return await storage.GetCount(cancellationToken);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation($"GetCountStudents выполнен за {sw.ElapsedMilliseconds} мс");
        }
    }
}