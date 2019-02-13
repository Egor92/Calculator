using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using Calculator.Wpf.Common.Utils;

namespace Calculator.Wpf.Common.Controls
{
    //https://www.source-weave.com/blog/custom-wpf-window
    //https://habr.com/ru/post/158561/
    public class CustomChromeWindow : Window
    {
        private Grid _windowRoot;
        private FrameworkElement _layoutRoot;
        private Button _minimizeButton;
        private Button _maximizeButton;
        private Button _restoreButton;
        private Button _closeButton;
        private Grid _headerBar;

        static CustomChromeWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomChromeWindow), new FrameworkPropertyMetadata(typeof(CustomChromeWindow)));
        }

        private T GetRequiredTemplateChild<T>(string childName)
            where T : DependencyObject
        {
            return GetTemplateChild(childName) as T;
        }

        public override void OnApplyTemplate()
        {
            _windowRoot = GetRequiredTemplateChild<Grid>("WindowRoot");
            _layoutRoot = GetRequiredTemplateChild<FrameworkElement>("LayoutRoot");
            _minimizeButton = GetRequiredTemplateChild<Button>("MinimizeButton");
            _maximizeButton = GetRequiredTemplateChild<Button>("MaximizeButton");
            _restoreButton = GetRequiredTemplateChild<Button>("RestoreButton");
            _closeButton = GetRequiredTemplateChild<Button>("CloseButton");
            _headerBar = GetRequiredTemplateChild<Grid>("PART_HeaderBar");

            if (_closeButton != null)
            {
                _closeButton.Click += CloseButton_Click;
            }

            if (_minimizeButton != null)
            {
                _minimizeButton.Click += MinimizeButton_Click;
            }

            if (_restoreButton != null)
            {
                _restoreButton.Click += RestoreButton_Click;
            }

            if (_maximizeButton != null)
            {
                _maximizeButton.Click += MaximizeButton_Click;
            }

            _headerBar?.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnHeaderBarMouseLeftButtonDown));

            base.OnApplyTemplate();
        }

        private void ToggleWindowState()
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleWindowState();
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleWindowState();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected virtual void OnHeaderBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(this);
            int headerBarHeight = (int)_headerBar.ActualHeight;
            int leftmostClickableOffset = 36;

            if (position.X - _layoutRoot.Margin.Left <= leftmostClickableOffset && position.Y <= headerBarHeight)
            {
                if (e.ClickCount != 2)
                {
                    OpenSystemContextMenu(e);
                }
                else
                {
                    Close();
                }

                e.Handled = true;
                return;
            }

            if (e.ClickCount == 2 && ResizeMode == ResizeMode.CanResize)
            {
                ToggleWindowState();
                return;
            }

            DragMove();
        }

        private void OpenSystemContextMenu(MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(this);
            Point screen = PointToScreen(position);
            int num = 36;
            if (position.Y < num)
            {
                IntPtr handle = (new WindowInteropHelper(this)).Handle;
                IntPtr systemMenu = SystemMenuUtils.GetSystemMenu(handle, false);
                if (WindowState != WindowState.Maximized)
                {
                    SystemMenuUtils.EnableMenuItem(systemMenu, 61488, 0);
                }
                else
                {
                    SystemMenuUtils.EnableMenuItem(systemMenu, 61488, 1);
                }

                int num1 = SystemMenuUtils.TrackPopupMenuEx(systemMenu, SystemMenuUtils.TPM_LEFTALIGN | SystemMenuUtils.TPM_RETURNCMD, Convert.ToInt32(screen.X + 2),
                                                        Convert.ToInt32(screen.Y + 2), handle, IntPtr.Zero);
                if (num1 == 0)
                {
                    return;
                }

                SystemMenuUtils.PostMessage(handle, 274, new IntPtr(num1), IntPtr.Zero);
            }
        }
    }
}
