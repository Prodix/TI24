using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class TestingResult
{
    public int Id { get; set; }

    public int TestId { get; set; }
    
    public ProgressType Status { get; set; }

    public int EmployeeId { get; set; }

    public int Grade { get; set; }

    public int MistakeQuantity { get; set; }

    public DateOnly DateComletion { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ModuleTest Test { get; set; } = null!;
}
