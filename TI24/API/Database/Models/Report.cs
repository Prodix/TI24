using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class Report
{
    public int Id { get; set; }

    public ReportType Type { get; set; }
    
    public DateOnly DateGeneration { get; set; }

    public int MistakeQuantity { get; set; }

    public int CompletionRate { get; set; }
}
