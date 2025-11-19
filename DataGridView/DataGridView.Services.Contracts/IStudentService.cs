using DataGridView.Entities;

namespace DataGridView.Services.Contracts;

/// <summary>
/// Интерфейс для сервиса студентов
/// </summary>
public interface IStudentService
{
    /// <summary>
    /// Добавить студента
    /// </summary>
    public Task Add(Student student, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удалить студента
    /// </summary>
    public Task Remove(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновить студента
    /// </summary>
    public Task Update(Student student, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить всех студентов
    /// </summary>
    public Task<ICollection<Student>> GetAll(CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить всех студентов у которых общее кол-во баллов больше указанного
    /// </summary>
    public Task<int> Goida(int count, CancellationToken cancellationToken);
}