using DataGridView.Entities;

namespace DataGridView.Services.Contracts;

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
    public Task Remove(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновить студента
    /// </summary>
    public Task Update(Student student, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить студента по идентификатору
    /// </summary>
    public Task GetById(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить всех студентов
    /// </summary>
    public Task<ICollection<Student>> GetAll(CancellationToken cancellationToken);
}