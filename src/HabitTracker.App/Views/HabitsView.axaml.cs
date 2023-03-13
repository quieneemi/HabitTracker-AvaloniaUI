using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HabitTracker.App.Views;

public partial class HabitsView : UserControl
{
    public HabitsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}