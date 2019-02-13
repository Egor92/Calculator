using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace Calculator.DesktopApplication.Behaviors
{
    public class SetBorderHighlightingBehavior : Behavior<Control>
    {
        private Window _window;
        private RoutedEventHandler _previewMouseMoveEventHandler;

        protected override void OnAttached()
        {
            _window = Window.GetWindow(AssociatedObject);
            _previewMouseMoveEventHandler = OnPreviewMouseMove;
            _window?.AddHandler(UIElement.PreviewMouseMoveEvent, _previewMouseMoveEventHandler);
        }

        protected override void OnDetaching()
        {
            _window?.RemoveHandler(UIElement.PreviewMouseMoveEvent, _previewMouseMoveEventHandler);
        }

        private void OnPreviewMouseMove(object sender, RoutedEventArgs e)
        {
            var mousePosition = Mouse.GetPosition(AssociatedObject);
            var radius = 100;
            AssociatedObject.BorderBrush = new RadialGradientBrush(Colors.Gray, Colors.Transparent)
            {
                RadiusX = radius,
                RadiusY = radius,
                Center = mousePosition,
                GradientOrigin = mousePosition,
                MappingMode = BrushMappingMode.Absolute,
            };
        }
    }
}
