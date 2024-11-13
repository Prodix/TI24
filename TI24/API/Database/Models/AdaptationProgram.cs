using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class AdaptationProgram
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateCreation { get; set; }

    public virtual ICollection<EmployeeProgram> EmployeePrograms { get; set; } = new List<EmployeeProgram>();

    public virtual ICollection<ProgramModule> ProgramModules { get; set; } = new List<ProgramModule>();
}
