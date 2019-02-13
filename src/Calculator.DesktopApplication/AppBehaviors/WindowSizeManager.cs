using System;
using System.Windows;
using Calculator.DesktopApplication.Constants;
using Calculator.Wpf.Common.AppBehaviors;
using ReactiveUI;

namespace Calculator.DesktopApplication.AppBehaviors
{
    public sealed class WindowSizeManager : IAppBehavior
    {
        private readonly Window _window;
        private readonly IMessageBus _messageBus;

        public WindowSizeManager(Window window, IMessageBus messageBus)
        {
            _window = window;
            _messageBus = messageBus;
        }

        public IDisposable Attach()
        {
            return _messageBus.Listen<Size>(AppEvents.SizeChangingRequested)
                              .Subscribe(OnSizeChangingRequested);

            void OnSizeChangingRequested(Size size)
            {
                _window.Height = size.Height;
                _window.Width = size.Width;
            }
        }
    }
}
