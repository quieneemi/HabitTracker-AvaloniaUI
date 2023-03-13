using HabitTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Data;

public class HabitDbContext : DbContext
{
    public DbSet<Habit>? HabitSet { get; set; }
    public DbSet<Check>? CheckSet { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=habits.db");
    }
}