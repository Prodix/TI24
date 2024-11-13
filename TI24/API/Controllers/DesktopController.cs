using API.Database;
using API.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("/api/desktop")]
public class DesktopController : Controller
{
    private PostgresContext _db;
    
    public DesktopController(PostgresContext db)
    {
        _db = db;
    }

    [HttpGet]
    [Route("modules")]
    public IActionResult GetModules()
    {
        return Ok(_db.Modules.ToList());
    }

    [HttpGet]
    [Route("employees")]
    public IActionResult GetEmployees()
    {
        return Ok(_db.Employees.ToList());
    }

    [HttpGet]
    [Route("positions")]
    public IActionResult GetPositions()
    {
        return Ok(_db.Positions.ToList());
    }

    [HttpPost]
    [Route("modules/create")]
    public IActionResult CreateModule(Module module)
    {
        _db.Modules.Add(module);
        _db.SaveChanges();
        return Ok("Модуль создан");
    }
    
    [HttpPost]
    [Route("programs/create")]
    public IActionResult CreateProgram(AdaptationProgram program)
    {
        _db.AdaptationPrograms.Add(program);
        _db.SaveChanges();
        return Ok("Программа создана");
    }

    [HttpPost]
    [Route("reports/create")]
    public IActionResult CreateReport(Report report)
    {
        _db.Reports.Add(report);
        _db.SaveChanges();
        return Ok("Отчёт создан");
    }

    [HttpPost]
    [Route("reports/update")]
    public IActionResult UpdateReport(Report report)
    {
        _db.Reports.Update(report);
        _db.SaveChanges();
        return Ok("Отчёт обновлен");
    }

    [HttpPost]
    [Route("reports/delete")]
    public IActionResult DeleteReport(Report report)
    {
        _db.Reports.Remove(report);
        _db.SaveChanges();
        return Ok("Отчёт удален");
    }
    
    [HttpPost]
    [Route("modules/mentors/add")]
    public IActionResult AddMentor(int id, int mentorId, int employeeId)
    {
        _db.ModuleMentorings.Add(new ModuleMentoring()
        {
            EmployeeId = employeeId,
            MentorId = mentorId,
            ModuleId = id
        });
        _db.SaveChanges();
        return Ok("Ментор добавлен");
    }
    
    [HttpPost]
    [Route("modules/mentors/update")]
    public IActionResult UpdateMentor(int id, int mentorId, int employeeId)
    {
        var mentoring = _db.ModuleMentorings.First(x => x.Id == id);
        mentoring.MentorId = mentorId;
        mentoring.EmployeeId = employeeId;
        
        _db.ModuleMentorings.Add(mentoring);
        _db.SaveChanges();
        
        return Ok("Ментор обновлен");
    }
    
    [HttpPost]
    [Route("modules/mentors/delete")]
    public IActionResult DeleteMentor(int id)
    {
        _db.ModuleMentorings.Where(x => x.Id == id).ExecuteDelete();
        _db.SaveChanges();
        return Ok("Ментор удалён");
    }
}