using System;
using System.Windows;
using Calculator.DesktopApplication.Constants;
using Calculator.DesktopApplication.Controls;
using Calculator.Wpf.Common.AppBehaviors;
using ReactiveUI;

namespace Calculator.DesktopApplication.AppBehaviors
{
    public sealed class WindowSizeManager : IAppBehavior
    {
        private readonly Shell _shell;
        private readonly IMessageBus _messageBus;

        public WindowSizeManager(Shell shell, IMessageBus messageBus)
        {
            _shell = shell;
            _messageBus = messageBus;
        }

        public IDisposable Attach()
        {
            return _messageBus.Listen<Size>(AppEvents.SizeChangingRequested)
                              .Subscribe(OnSizeChangingRequested);

            void OnSizeChangingRequested(Size size)
            {
                _shell.Height = size.Height;
                _shell.Width = size.Width;
            }
        }
    }
}
