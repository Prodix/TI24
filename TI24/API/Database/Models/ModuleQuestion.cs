using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class ModuleQuestion
{
    public int Id { get; set; }

    public int TestId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public virtual ModuleTest Test { get; set; } = null!;
}
