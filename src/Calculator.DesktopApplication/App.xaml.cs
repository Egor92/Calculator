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
            var standardCalculatorVM = new StandardCalculatorViewModel(calculator);
            var narrowCalculatorVM = new NarrowCalculatorViewModel(calculator);
            var messageBus = new MessageBus();
            var shellVM = new ShellViewModel(messageBus, standardCalculatorVM, narrowCalculatorVM);

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
            var windowSizeManaging = windowSizeManager.StartManaging();

            shell.ShowDialog();

            windowSizeManaging.Dispose();
        }
    }
}
