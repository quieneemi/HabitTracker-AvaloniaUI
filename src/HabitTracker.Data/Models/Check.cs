namespace HabitTracker.Data.Models;

public class Check
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsChecked { get; set; }
    
    public Check(DateTime date, bool isChecked = false)
    {
        Date = date;
        IsChecked = isChecked;
    }
}