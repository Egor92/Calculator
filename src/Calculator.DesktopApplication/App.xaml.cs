using System.Windows;
using Calculator.DesktopApplication.AppBehaviors;
using Calculator.DesktopApplication.Controls;
using Calculator.DesktopApplication.ViewModels;
using Calculator.DesktopApplication.Views;
using ReactiveUI;

namespace Calculator.DesktopApplication
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var calculator = new BusinessLogic.Calculator();
            var calculatorVM = new CalculatorViewModel(calculator);
            var messageBus = new MessageBus();
            var shellVM = new ShellViewModel(messageBus, calculatorVM);

            var shell = new Shell
            {
                Title = "Calculator",
                MinHeight = 100,
                MinWidth = 100,
                Height = 508,
                Width = 322,
                Content = new ShellView
                {
                    DataContext = shellVM,
                },
            };

            var windowSizeManager = new WindowSizeManager(shell, messageBus);
            windowSizeManager.StartManaging();

            shell.Show();
        }
    }
}
