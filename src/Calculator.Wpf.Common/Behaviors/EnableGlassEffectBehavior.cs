using System.Windows;
using System.Windows.Interactivity;
using Calculator.Wpf.Common.Utils;

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
