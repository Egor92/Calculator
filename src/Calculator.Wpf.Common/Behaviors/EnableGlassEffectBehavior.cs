using System;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Windows.Media;
using Calculator.Wpf.Common.Utils;
using Calculator.Wpf.Common.Xaml;

namespace Calculator.Wpf.Common.Behaviors
{
    public class EnableGlassEffectBehavior : Behavior<Window>
    {
        #region Fields

        private static readonly Color BlurUtilColor = Color.FromArgb(1, 0, 0, 0);
        private static readonly SolidColorBrush BlurUtilBackground = new SolidColorBrush(BlurUtilColor);
        private Brush _originalBackground;

        #endregion

        #region Background

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Color), typeof(EnableGlassEffectBehavior),
                                        new PropertyMetadata(Colors.Transparent, OnBackgroundChanged));

        public Color Background
        {
            get { return (Color) GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        private static void OnBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var enableGlassEffectBehavior = (EnableGlassEffectBehavior) sender;
            enableGlassEffectBehavior.OnBackgroundChanged();
        }

        private void OnBackgroundChanged()
        {
            UpdateBlur();
        }

        #endregion

        #region KeepBlurEffectWhenInactive

        public static readonly DependencyProperty KeepBlurEffectWhenInactiveProperty =
            DependencyProperty.Register("KeepBlurEffectWhenInactive", typeof(bool), typeof(EnableGlassEffectBehavior),
                                        new PropertyMetadata(OnKeepBlurEffectWhenInactiveChanged));

        public bool KeepBlurEffectWhenInactive
        {
            get { return (bool) GetValue(KeepBlurEffectWhenInactiveProperty); }
            set { SetValue(KeepBlurEffectWhenInactiveProperty, value); }
        }

        private static void OnKeepBlurEffectWhenInactiveChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var enableGlassEffectBehavior = (EnableGlassEffectBehavior) sender;
            enableGlassEffectBehavior.OnKeepBlurEffectWhenInactiveChanged();
        }

        private void OnKeepBlurEffectWhenInactiveChanged()
        {
            UpdateBlur();
        }

        #endregion

        protected override void OnAttached()
        {
            _originalBackground = AssociatedObject.Background;
            BehaviorHelper.InvokeWhenWillBeLoaded(AssociatedObject, UpdateBlur);
            AssociatedObject.Activated += OnIsActiveChanged;
            AssociatedObject.Deactivated += OnIsActiveChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Activated -= OnIsActiveChanged;
            AssociatedObject.Deactivated -= OnIsActiveChanged;
        }

        private void OnIsActiveChanged(object sender, EventArgs e)
        {
            UpdateBlur();
        }

        private void UpdateBlur()
        {
            if (AssociatedObject == null)
                return;

            var windowHelper = new WindowInteropHelper(AssociatedObject);

            if (AssociatedObject.IsActive || KeepBlurEffectWhenInactive)
            {
                var a = Background.A;
                var r = Background.R;
                var g = Background.G;
                var b = Background.B;

                WindowUtils.EnableBlur(windowHelper, a, r, g, b);

                AssociatedObject.Background = BlurUtilBackground;
            }
            else
            {
                AssociatedObject.Background = _originalBackground;
                WindowUtils.DisableBlur(windowHelper);
            }
        }
    }
}
