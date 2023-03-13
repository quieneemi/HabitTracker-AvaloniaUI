using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HabitTracker.App.Views;

public partial class ChecksView : UserControl
{
    public ChecksView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}