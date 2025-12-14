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
    /// Удалить студента
    /// </summary>
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid studentId, CancellationToken cancellationToken)
    {
        await studentService.Remove(studentId, cancellationToken);
        return RedirectToAction("Index");
    }
    
    /// <summary>
    /// Обновить студента
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var student = await studentService.GetById(id, cancellationToken);
        return PartialView("EditStudentModal", student);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(Student student, CancellationToken cancellationToken)
    {
        await studentService.Update(student, cancellationToken);
        return RedirectToAction("Index", "Home");
    }
}