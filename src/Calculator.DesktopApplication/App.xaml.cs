﻿using System;
using System.Linq;
using System.Windows;
using Calculator.BusinessLogic;
using Calculator.DesktopApplication.AppBehaviors;
using Calculator.DesktopApplication.Controls;
using Calculator.DesktopApplication.ViewModels;
using Calculator.DesktopApplication.Views;
using Calculator.Wpf.Common.AppBehaviors;
using Prism.Ioc;
using ReactiveUI;

namespace Calculator.DesktopApplication
{
    public partial class App
    {
        private IDisposable[] _appBehaviorAttachings;

        private readonly Func<IContainerProvider, IAppBehavior>[] _appBehaviorFuncs =
        {
            container => container.Resolve<WindowSizeManager>(),
            container => container.Resolve<ApplyKeyboardActionsToCalculatorAppBehavior>(),
        };

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _appBehaviorAttachings = _appBehaviorFuncs.Select(x => x(Container))
                                                      .Select(x => x.Attach())
                                                      .ToArray();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            foreach (var appBehaviorAttaching in _appBehaviorAttachings)
            {
                appBehaviorAttaching.Dispose();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(Window), new Shell());
            containerRegistry.RegisterSingleton<ICalculator, BusinessLogic.Calculator>();
            containerRegistry.RegisterInstance(typeof(IMessageBus), new MessageBus());
            containerRegistry.RegisterSingleton<ShellViewModel>();
            containerRegistry.RegisterSingleton<StandardCalculatorViewModel>();
            containerRegistry.RegisterSingleton<NarrowCalculatorViewModel>();
        }

        protected override Window CreateShell()
        {
            var window = Container.Resolve<Window>();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Content = new ShellView
            {
                DataContext = Container.Resolve<ShellViewModel>(),
            };
            return window;
        }
    }
}
