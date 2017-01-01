using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var app = new Application();
        var window = new Window();
        window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        window.WindowState = WindowState.Maximized;
        window.Title = "SystemColors";

        var content = new ListBox();

        foreach (var prop in typeof(SystemColors).GetProperties().Where(p => p.PropertyType == typeof(SolidColorBrush)))
        {
            var brush = prop.GetValue(null) as SolidColorBrush;
            var rect = new Rectangle() { Width = 100, Height = 20, Fill = brush };
            var panel = new StackPanel() { Orientation = Orientation.Horizontal };
            panel.Children.Add(new TextBlock() { Text = prop.Name, Width = 200 });
            panel.Children.Add(rect);
            content.Items.Add(panel);
        }

        window.Content = content;

        app.Run(window);
    }
}