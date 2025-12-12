using DataGridView.Entities;

namespace DataGridView.Repositories.Contracts;

/// <summary>
/// Интерфейс хранилища
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Добавить студента
    /// </summary>
    public Task Add(Student student, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удалить студента
    /// </summary>
    public Task Remove(Student student, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновить студента
    /// </summary>
    public Task Update(Student student, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить студента по идентификатору
    /// </summary>
    public Task<Student?> GetById(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить всех студентов
    /// </summary>
    public Task<List<Student>> GetAll(CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить количество студентов
    /// </summary>
    public Task<int> GetCount(CancellationToken cancellationToken);
}