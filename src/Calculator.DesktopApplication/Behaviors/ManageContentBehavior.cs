using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Xaml.Behaviors;

namespace Calculator.DesktopApplication.Behaviors
{
    [ContentProperty(nameof(ControlCases))]
    public class ManageContentBehavior : Behavior<ContentControl>
    {
        #region Properties

        #region ControlCases

        public static readonly DependencyProperty ControlCasesProperty = DependencyProperty.Register("ControlCases", typeof(List<ICase<Size, UIElement>>),
                                                                                                     typeof(ManageContentBehavior),
                                                                                                     new PropertyMetadata(new List<ICase<Size, UIElement>>(),
                                                                                                                          OnControlCasesChanged));

        public List<ICase<Size, UIElement>> ControlCases
        {
            get { return (List<ICase<Size, UIElement>>) GetValue(ControlCasesProperty); }
            set { SetValue(ControlCasesProperty, value); }
        }

        private static void OnControlCasesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var manageContentBehavior = (ManageContentBehavior) sender;
            manageContentBehavior.OnControlCasesChanged();
        }

        private void OnControlCasesChanged()
        {
            UpdateContent();
        }

        #endregion

        #region DefaultContent

        public static readonly DependencyProperty DefaultContentProperty =
            DependencyProperty.Register("DefaultContent", typeof(ContentControl), typeof(ManageContentBehavior), new PropertyMetadata(OnDefaultContentChanged));

        public ContentControl DefaultContent
        {
            get { return (ContentControl) GetValue(DefaultContentProperty); }
            set { SetValue(DefaultContentProperty, value); }
        }

        private static void OnDefaultContentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var manageContentBehavior = (ManageContentBehavior) sender;
            manageContentBehavior.OnDefaultContentChanged();
        }

        private void OnDefaultContentChanged()
        {
            UpdateContent();
        }

        #endregion

        #endregion

        protected override void OnAttached()
        {
            AssociatedObject.SizeChanged += AssociatedObject_SizeChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SizeChanged -= AssociatedObject_SizeChanged;
        }

        private void AssociatedObject_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateContent();
        }

        private void UpdateContent()
        {
            if (AssociatedObject != null)
            {
                AssociatedObject.Content = GetSuitableContent();
            }
        }

        private UIElement GetSuitableContent()
        {
            var renderSize = AssociatedObject.RenderSize;
            var matchedCase = ControlCases?.FirstOrDefault(x => x.IsMatched(renderSize));
            if (matchedCase == null)
            {
                return DefaultContent;
            }

            return matchedCase.Result;
        }
    }
}
