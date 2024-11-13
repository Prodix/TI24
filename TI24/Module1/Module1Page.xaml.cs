using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using API.Database;
using API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Module = System.Reflection.Module;

namespace Module1;

public partial class Module1Page : Page
{
    private ObservableCollection<object> Module { get; set; } = new();
    
    public Module1Page()
    {
        InitializeComponent();
        var date = DateOnly.FromDateTime(DateTime.Now);
        using var db = new PostgresContext();
        Module = new ObservableCollection<object>(db.Modules
            .Include(x => x.ResponsiblePersonNavigation)
            .Select(x => new
            {
                Info = x, 
                Color = date > x.DateRelease.AddDays(-7)
                    ? "Red" 
                    : x.Status == "draft"
                        ? "Yellow"
                        : "Green"
            })
            .ToList());
        ModulesElement.ItemsSource = Module;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ModuleCreationPage());
    }
}