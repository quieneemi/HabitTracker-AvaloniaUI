namespace HabitTracker.Data.Models;

public class Habit
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsFinished { get; set; }
    public ICollection<Check> Checks { get; set; }
    
    public int CheckedDays => Checks.Count(check => check.IsChecked);

    public Habit()
    {
        Title = string.Empty;
        Description = string.Empty;
        Checks = new List<Check>();
    }
    
    public Habit(string title, string description, ICollection<Check> checks)
    {
        Title = title;
        Description = description;
        Checks = checks;
    }
}