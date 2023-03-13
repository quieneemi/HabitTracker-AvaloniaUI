using System;
using System.Reactive;
using System.Reactive.Linq;
using HabitTracker.Data;
using HabitTracker.Data.Models;
using ReactiveUI;

namespace HabitTracker.App.ViewModels;

public class CreationViewModel : ViewModelBase
{
    private string _title = string.Empty;
    private string _description = string.Empty;
    private DateTimeOffset _date;
    private int _days;
    
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }
    public int Days
    {
        get => _days;
        set => this.RaiseAndSetIfChanged(ref _days, value);
    }
    
    public ReactiveCommand<Unit, Habit> CreateCommand { get; }

    public CreationViewModel()
    {
        _date = DateTime.Now;
        _days = 2;
        
        var canCreate = this.WhenAnyValue(
                x => x.Title, x => x.Description,
                (title, description) =>
                    !string.IsNullOrEmpty(title) &&
                    !string.IsNullOrEmpty(description))
            .DistinctUntilChanged();

        CreateCommand = ReactiveCommand.Create(
            execute: () => HabitDbManager.CreateHabit(Title, Description, Date.DateTime, Days),
            canExecute: canCreate);
    }
}