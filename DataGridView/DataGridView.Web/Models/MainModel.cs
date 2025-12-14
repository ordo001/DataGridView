using DataGridView.Entities;

namespace DataGridView.Web.Models;

/// <summary>
/// Модель для главной страницы
/// </summary>
public class MainModel
{
    /// <summary>
    /// Список студентов
    /// </summary>
    public required IEnumerable<Student> Students { get; set; }
    
    /// <summary>
    /// Количество студентов
    /// </summary>
    public int CountStudents  { get; set; }
    
    /// <summary>
    /// Количество студентов меньше мин кол-во очков
    /// </summary>
    public int GetStudentsByMinScore {get; set;}
}