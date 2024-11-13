using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class EmployeeProgram
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int ProgramId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual AdaptationProgram Program { get; set; } = null!;
}
