using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class ProgramModule
{
    public int Id { get; set; }

    public int ProgramId { get; set; }

    public int ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual AdaptationProgram Program { get; set; } = null!;
}
