using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using API.Database;
using Microsoft.EntityFrameworkCore;

namespace Module1;

public partial class Module2Page : Page
{
    public ObservableCollection<object> Module { get; set; } = new();
    
    public Module2Page()
    {
        InitializeComponent();
        using var db = new PostgresContext();

        var employees = db.Employees.ToList();
        
        Module = new ObservableCollection<object>(db.Modules
            .Include(x => x.ResponsiblePersonNavigation)
            .Select(x => new
            {
                Info = x, 
                AvailableMentors = employees
            })
            .ToList());
        ModulesElement.ItemsSource = Module;
    }
}