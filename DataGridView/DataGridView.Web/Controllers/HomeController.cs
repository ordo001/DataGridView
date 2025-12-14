using DataGridView.Entities;
using DataGridView.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DataGridView.Web.Controllers;

/// <summary>
/// Кон
/// </summary>
/// <param name="studentService"></param>
public class HomeController(IStudentService studentService) : Controller
{
    /// <summary>
    /// Получить всех студентов
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var students = await studentService.GetAll(cancellationToken);
        return View(students);
    }
    
    /// <summary>
    /// Получить станицу обновления студентов 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> EditStudentPage(Guid studentId, CancellationToken cancellationToken)
    {
        var student = await studentService.GetById(studentId, cancellationToken);
        if (student is null)
        {
            return NotFound();
        }
        return View(nameof(AddStudentPage),student);
    }
    
    /// <summary>
    /// Получить станицу добавления студентов 
    /// </summary>
    [HttpGet]
    public IActionResult AddStudentPage(CancellationToken cancellationToken)
    {
        return View();
    }
    
    /// <summary>
    /// Удалить студента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(Guid studentId, CancellationToken cancellationToken)
    {
        await studentService.Remove(studentId, cancellationToken);
        return RedirectToAction("Index");
    }
    
    /// <summary>
    /// Обновить студента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Update(Student student, CancellationToken cancellationToken)
    {
        await studentService.Update(student, cancellationToken);
        return RedirectToAction("Index");
    }
    
    
    /// <summary>
    /// Добавить студента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(Student student, CancellationToken cancellationToken)
    {
        await studentService.Add(student, cancellationToken);
        return RedirectToAction("Index");
    }
}