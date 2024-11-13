using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class AdaptationEvent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Descrition { get; set; } = null!;
    
    public EventType Type { get; set; }

    public virtual ICollection<ModuleEvent> ModuleEvents { get; set; } = new List<ModuleEvent>();
}
