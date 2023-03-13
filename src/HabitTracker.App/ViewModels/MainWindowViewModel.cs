using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using HabitTracker.Data;
using HabitTracker.Data.Models;
using ReactiveUI;

namespace HabitTracker.App.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;
    private Habit? _selectedHabit;
    
    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
    
    public Habit? SelectedItem
    {
        get => _selectedHabit;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedHabit, value);
            OnItemSelected();
        }
    }
    
    private HabitsViewModel Habits { get; }
    
    public MainWindowViewModel()
        => _content = Habits = new HabitsViewModel(HabitDbManager.GetData());
    
    private void OnItemSelected()
    {
        var habit = SelectedItem;
        
        if (habit is null) return;

        if (!habit.IsFinished)
        {
            var vm = new ChecksViewModel(habit.Checks);
            Observable.Merge(vm.CompleteCommand)
                .Take(1)
                .Subscribe(_ =>
                {
                    habit.IsFinished = true;
                    ShowSummaryView(habit);
                });
            Content = vm;
        }
        else
        {
            ShowSummaryView(habit);
        }
    }
    
    public void OnCreateCommand()
    {
        var vm = new CreationViewModel();
        Observable.Merge(vm.CreateCommand)
            .Take(1)
            .Subscribe(x =>
            {
                Habits.Items.Add(x);
                ShowMainView();
            });
        Content = vm;
    }
    
    public async void OnDeleteCommand(Habit item)
    {
        await Task.Run(() => HabitDbManager.DeleteHabit(item));
        Habits.Items.Remove(item);
        ShowMainView();
    }
    
    public void ShowMainView()
    {
        _selectedHabit = null;
        Content = Habits;
    }
    
    private void ShowSummaryView(Habit habit)
        => Content = new SummaryViewModel(habit.Title, habit.CheckedDays, habit.Checks.Count);
}