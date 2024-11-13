using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class ModuleEvent
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public int EventId { get; set; }

    public virtual AdaptationEvent Event { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
