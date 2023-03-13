using System.Collections.Generic;
using System.Collections.ObjectModel;
using HabitTracker.Data.Models;

namespace HabitTracker.App.ViewModels;

public class HabitsViewModel : ViewModelBase
{
    public ObservableCollection<Habit> Items { get; set; }
    
    public HabitsViewModel(IEnumerable<Habit> habits)
        => Items = new ObservableCollection<Habit>(habits);
}