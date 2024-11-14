using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public bool IsMentor { get; set; }

    public int DepartmentId { get; set; }

    public int PositionId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<EmployeeProgram> EmployeePrograms { get; set; } = new List<EmployeeProgram>();

    public virtual ICollection<ModuleAgreed> ModuleAgreeds { get; set; } = new List<ModuleAgreed>();

    public virtual ICollection<ModuleMentoring> ModuleMentoringEmployees { get; set; } = new List<ModuleMentoring>();

    public virtual ICollection<ModuleMentoring> ModuleMentoringMentors { get; set; } = new List<ModuleMentoring>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<TestingResult> TestingResults { get; set; } = new List<TestingResult>();

    public override string ToString()
    {
        return $"{Id} | {FirstName} {LastName} {MiddleName}";
    }
}
