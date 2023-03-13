using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HabitTracker.App.Views;

public partial class CreationView : UserControl
{
    public CreationView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}