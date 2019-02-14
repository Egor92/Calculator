using System;
using System.Reactive.Disposables;
using System.Windows;

namespace Calculator.Wpf.Common.Xaml
{
    public static class BehaviorHelper
    {
        public static IDisposable InvokeWhenWillBeLoaded(FrameworkElement element, Action action)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (element.IsLoaded)
            {
                action();
                return Disposable.Empty;
            }

            IDisposable subscription = null;

            element.Loaded += LoadedHandler;
            return subscription = Disposable.Create(() =>
            {
                element.Loaded -= LoadedHandler;
            });

            void LoadedHandler(object x1, RoutedEventArgs x2)
            {
                subscription?.Dispose();
                action();
            }
        }
    }
}
