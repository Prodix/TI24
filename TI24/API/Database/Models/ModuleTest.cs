using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class ModuleTest
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public string Title { get; set; } = null!;
    
    public TestingType Type { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual ICollection<ModuleQuestion> ModuleQuestions { get; set; } = new List<ModuleQuestion>();

    public virtual ICollection<TestingResult> TestingResults { get; set; } = new List<TestingResult>();
}
