﻿using System;
using System.Collections.Generic;

namespace API.Database.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    
    public override string ToString() => Name;
}
