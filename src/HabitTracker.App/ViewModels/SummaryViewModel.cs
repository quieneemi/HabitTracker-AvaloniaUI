namespace HabitTracker.App.ViewModels;

public class SummaryViewModel : ViewModelBase
{
    public string Title { get; }
    public string DaysCheckedStat { get; }

    public SummaryViewModel(string title, int checkedDays, int totalDays)
    {
        Title = title;
        DaysCheckedStat = $"{checkedDays}/{totalDays}";
    }
}