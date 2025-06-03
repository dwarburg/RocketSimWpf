using System.Windows;
using Fluent;

namespace RocketSimWpf;

public partial class MainWindow : RibbonWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        // Close the application
        Application.Current.Shutdown();
    }
}
