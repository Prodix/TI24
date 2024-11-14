using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using API.Database;
using API.Database.Models;
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
        Employees.ItemsSource = employees;
        Departments.ItemsSource = db.Departments.ToList();
        Positions.ItemsSource = db.Positions.ToList();
        
        Module = new ObservableCollection<object>(db.Modules
            .Select(m => new 
            {
                Info = m,
                Mentors = employees,
                SelectedMentors = new List<Employee>(),
                IsMarked = false
            }).ToList());
        ModulesElement.ItemsSource = Module;
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var element = sender as ListView;
        var module = ((StackPanel)((ScrollViewer)element.Parent).Parent).DataContext as dynamic;
        module.SelectedMentors.Clear();
        module.SelectedMentors.AddRange(element.SelectedItems.Cast<Employee>().ToList());
    }

    private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
    {
        var element = sender as CheckBox;
        var module = ((StackPanel)((StackPanel)element.Parent).Parent).DataContext as dynamic;
        var moduleElement = Module.IndexOf(module);
        Module[moduleElement] = new
        {
            module.Info,
            module.Mentors,
            module.SelectedMentors,
            IsMarked = true
        };
        ModulesElement.ItemsSource = Module;
    }

    private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
    {
        var element = sender as CheckBox;
        var module = ((StackPanel)((StackPanel)element.Parent).Parent).DataContext as dynamic;
        var moduleElement = Module.IndexOf(module);
        Module[moduleElement] = new
        {
            module.Info,
            module.Mentors,
            module.SelectedMentors,
            IsMarked = false
        };
        ModulesElement.ItemsSource = Module;
    }

    private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        
    }

    private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var text = (sender as TextBox)?.Text;
            using var db = new PostgresContext();
        
            var employees = db.Employees.ToList();
            Module = new ObservableCollection<object>(db.Modules
                .Where(x => x.Name.Contains(text))
                .Select(m => new 
                {
                    Info = m,
                    Mentors = employees,
                    SelectedMentors = new List<Employee>(),
                    IsMarked = false
                }).ToList());
            ModulesElement.ItemsSource = Module;
        }
    }
}