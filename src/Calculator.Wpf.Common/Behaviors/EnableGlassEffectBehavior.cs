using System.Windows;
using Calculator.Wpf.Common.Utils;
using Microsoft.Xaml.Behaviors;

namespace Calculator.Wpf.Common.Behaviors
{
    public class EnableGlassEffectBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            WindowUtils.EnableBlur(AssociatedObject);
        }
    }
}
