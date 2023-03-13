using HabitTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Data;

public static class HabitDbManager
{
    public static Habit CreateHabit(string title, string description, DateTime date, int days)
    {
        using var dbContext = new HabitDbContext();

        var checks = new List<Check>();
        for (var i = 0; i < days; i++)
            checks.Add(new Check(date.AddDays(i)));
        
        var habit = new Habit(title, description, checks);
        
        dbContext.CheckSet?.AddRange(checks);
        dbContext.Add(habit);
        dbContext.SaveChanges();

        return habit;
    }

    public static void DeleteHabit(Habit habit)
    {
        using var dbContext = new HabitDbContext();
        
        var dbHabit = dbContext.HabitSet!
            .Include(h => h.Checks)
            .First(h => h.Id == habit.Id);
        
        dbContext.RemoveRange(dbHabit.Checks);
        dbContext.Remove(dbHabit);
        dbContext.SaveChanges();
    }

    public static IEnumerable<Habit> GetData()
    {
        using var dbContext = new HabitDbContext();

        if (dbContext.HabitSet is null || !dbContext.HabitSet.Any())
            return new List<Habit>();
        
        var habits = new List<Habit>(dbContext.HabitSet.Include(x => x.Checks));
        habits.ForEach(UpdateHabitIsFinishedState);

        dbContext.SaveChanges();

        return new List<Habit>(habits);
    }

    public static void SyncCheck(Check check)
    {
        using var dbContext = new HabitDbContext();
        
        dbContext.CheckSet!
            .First(x => x.Date == check.Date)
            .IsChecked = check.IsChecked;
        
        dbContext.SaveChanges();
    }

    private static void UpdateHabitIsFinishedState(Habit habit)
    {
        if (habit.Checks.Last().Date < DateTime.Now || habit.Checks.Last().IsChecked)
            habit.IsFinished = true;
    }
}