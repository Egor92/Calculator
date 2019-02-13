using System.Windows;
using Calculator.Wpf.Common.Controls;

namespace Calculator.DesktopApplication.Controls
{
    public class Shell : CustomChromeWindow
    {
        static Shell()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Shell), new FrameworkPropertyMetadata(typeof(Shell)));
        }
    }
}
