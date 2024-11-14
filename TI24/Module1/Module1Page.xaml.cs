using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                    : x.Status == ModuleStatus.Draft
                        ? "Yellow"
                        : "Green"
            })
            .ToList());
        ModulesElement.ItemsSource = Module;
        
        var positions = db.Positions
            .Select(x => x.Name)
            .ToList();
        
        positions.Add("");

        Positions.ItemsSource = positions;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ModuleCreationPage());
    }

    private void Positions_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.AddedItems[0].ToString();
        var date = DateOnly.FromDateTime(DateTime.Now);
        using var db = new PostgresContext();
        Module = new ObservableCollection<object>(db.Modules
            .Include(x => x.ResponsiblePersonNavigation)
            .Include(x => x.ModulePositions)
            .Where(x => item == "" || x.ModulePositions.Any(e => e.Position.Name == item))
            .Select(x => new
            {
                Info = x, 
                Color = date > x.DateRelease.AddDays(-7)
                    ? "Red" 
                    : x.Status == ModuleStatus.Draft
                        ? "Yellow"
                        : "Green"
            })
            .ToList());
        ModulesElement.ItemsSource = Module;
    }

    private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var text = (sender as TextBox)?.Text;
        var date = DateOnly.FromDateTime(DateTime.Now);
        using var db = new PostgresContext();
        Module = new ObservableCollection<object>(db.Modules
            .Include(x => x.ResponsiblePersonNavigation)
            .Where(x => x.Name.Contains(text))
            .Select(x => new
            {
                Info = x, 
                Color = date > x.DateRelease.AddDays(-7)
                    ? "Red" 
                    : x.Status == ModuleStatus.Draft
                        ? "Yellow"
                        : "Green"
            })
            .ToList());
        ModulesElement.ItemsSource = Module;
    }
}