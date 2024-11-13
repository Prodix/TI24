using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class ModulePosition
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public int PositionId { get; set; }
    
    public ModuleStatus Status { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
