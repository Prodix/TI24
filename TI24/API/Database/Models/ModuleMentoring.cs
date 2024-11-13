using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class ModuleMentoring
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int ModuleId { get; set; }

    public int MentorId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Employee Mentor { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
