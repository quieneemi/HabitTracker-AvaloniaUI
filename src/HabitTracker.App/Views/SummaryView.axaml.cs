using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HabitTracker.App.Views;

public partial class SummaryView : UserControl
{
    public SummaryView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}