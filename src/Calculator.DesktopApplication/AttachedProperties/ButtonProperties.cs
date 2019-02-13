using System.Windows;

namespace Calculator.DesktopApplication.AttachedProperties
{
    public static class ButtonProperties
    {
        #region CornerRadius

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonProperties));

        public static void SetCornerRadius(DependencyObject element, CornerRadius value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }

        public static CornerRadius GetCornerRadius(DependencyObject element)
        {
            return (CornerRadius) element.GetValue(CornerRadiusProperty);
        }

        #endregion
    }
}
