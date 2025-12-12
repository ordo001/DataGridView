using System.Diagnostics;
using DataGridView.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using DataGridView.Web.Models;

namespace DataGridView.Web.Controllers;

public class HomeController(IStudentService studentService) : Controller
{

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var students = await studentService.GetAll(cancellationToken);
        return View(students);
    }
}