using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int ResponsiblePerson { get; set; }

    public int Duration { get; set; }

    public DateOnly DateRelease { get; set; }

    public string InfoSource { get; set; } = null!;

    public int? ParentModuleId { get; set; }

    public virtual ICollection<ModuleAgreed> ModuleAgreeds { get; set; } = new List<ModuleAgreed>();

    public virtual ICollection<ModuleEvent> ModuleEvents { get; set; } = new List<ModuleEvent>();

    public virtual ICollection<ModuleMentoring> ModuleMentorings { get; set; } = new List<ModuleMentoring>();

    public virtual ICollection<ModulePosition> ModulePositions { get; set; } = new List<ModulePosition>();

    public virtual ICollection<ModuleTest> ModuleTests { get; set; } = new List<ModuleTest>();

    public virtual ICollection<ProgramModule> ProgramModules { get; set; } = new List<ProgramModule>();

    public virtual Employee ResponsiblePersonNavigation { get; set; } = null!;
}
