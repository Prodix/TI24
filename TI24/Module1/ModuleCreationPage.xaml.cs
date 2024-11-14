using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using API.Database;
using API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Module1;

public partial class ModuleCreationPage : Page
{
    public Module Module { get; set; } = new Module();
    public List<Employee> EmployeesList { get; set; } = new();
    public List<Module> ModulesList { get; set; } = new();

    private DateTime _selectedDateTime = DateTime.Now;
    
    public DateTime SelectedDateTime
    {
        get { return _selectedDateTime; }
        set
        {
            Module.DateRelease = DateOnly.FromDateTime(value);
            _selectedDateTime = value;
        }
    }

    public List<Position> Positions { get; set; }
    
    public ModuleCreationPage()
    {
        InitializeComponent();
        DataContext = this;
        
        using var db = new PostgresContext();
        EmployeesList = db.Employees.ToList();
        ModulesList = db.Modules.ToList();
        Positions = db.Positions.ToList();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        using var db = new PostgresContext();

        var lastId = db.Modules.OrderBy(x => x.Id).Last().Id;
        
        var agreeds = EmplListView.SelectedItems.Cast<Employee>().Select(x => new ModuleAgreed
        {
            ModuleId = lastId + 1,
            EmployeeId = x.Id
        }).ToList();
        
        var positions = PosListView.SelectedItems.Cast<Position>().Select(x => new ModulePosition
        {
            ModuleId = lastId + 1,
            PositionId = x.Id
        }).ToList();

        Module.ResponsiblePerson = Module.ResponsiblePersonNavigation.Id;
        Module.ResponsiblePersonNavigation = null!;
        Module.Status = ModuleStatus.Draft;
        
        db.Modules.Add(Module);
        db.SaveChanges();
        db.ModuleAgreeds.AddRange(agreeds);
        db.ModulePositions.AddRange(positions);
        db.SaveChanges();

        NavigationService.Navigate(new Module1Page());
    }
}