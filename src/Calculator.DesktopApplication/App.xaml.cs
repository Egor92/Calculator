using System.Windows;
using Calculator.DesktopApplication.Controls;

namespace Calculator.DesktopApplication
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var shell = new Shell
            {
                Title = "Calculator",
            };
            shell.Show();
        }
    }
}
