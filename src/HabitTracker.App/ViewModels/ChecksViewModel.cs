using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using HabitTracker.Data;
using HabitTracker.Data.Models;
using ReactiveUI;

namespace HabitTracker.App.ViewModels;

public class ChecksViewModel : ViewModelBase
{
    public ObservableCollection<Check> Items { get; set; }
    
    public ReactiveCommand<Unit, Unit> CompleteCommand { get; }

    public ChecksViewModel(IEnumerable<Check> checks)
    {
        CompleteCommand = ReactiveCommand.Create(() => { });
        Items = new ObservableCollection<Check>(checks);
    }

    public async void OnChecked(Check check)
    {
        await Task.Run(() => HabitDbManager.SyncCheck(check));

        if (check.IsChecked && check == Items.Last())
            CompleteCommand.Execute().Subscribe();
    }
}