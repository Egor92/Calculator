using System.Windows;
using System.Windows.Media;

namespace Calculator.Wpf.Common.Helpers
{
    public static class ShellTitleBarButtonProperties
    {
        #region MouseOverBackground

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(ShellTitleBarButtonProperties));

        public static void SetMouseOverBackground(DependencyObject element, Brush value)
        {
            element.SetValue(MouseOverBackgroundProperty, value);
        }

        public static Brush GetMouseOverBackground(DependencyObject element)
        {
            return (Brush) element.GetValue(MouseOverBackgroundProperty);
        }

        #endregion

        #region MouseOverForeground

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(ShellTitleBarButtonProperties));

        public static void SetMouseOverForeground(DependencyObject element, Brush value)
        {
            element.SetValue(MouseOverForegroundProperty, value);
        }

        public static Brush GetMouseOverForeground(DependencyObject element)
        {
            return (Brush) element.GetValue(MouseOverForegroundProperty);
        }

        #endregion

        #region MousePressedBackground

        public static readonly DependencyProperty MousePressedBackgroundProperty =
            DependencyProperty.RegisterAttached("MousePressedBackground", typeof(Brush), typeof(ShellTitleBarButtonProperties));

        public static void SetMousePressedBackground(DependencyObject element, Brush value)
        {
            element.SetValue(MousePressedBackgroundProperty, value);
        }

        public static Brush GetMousePressedBackground(DependencyObject element)
        {
            return (Brush) element.GetValue(MousePressedBackgroundProperty);
        }

        #endregion

        #region MousePressedForeground

        public static readonly DependencyProperty MousePressedForegroundProperty =
            DependencyProperty.RegisterAttached("MousePressedForeground", typeof(Brush), typeof(ShellTitleBarButtonProperties));

        public static void SetMousePressedForeground(DependencyObject element, Brush value)
        {
            element.SetValue(MousePressedForegroundProperty, value);
        }

        public static Brush GetMousePressedForeground(DependencyObject element)
        {
            return (Brush) element.GetValue(MousePressedForegroundProperty);
        }

        #endregion
    }
}
