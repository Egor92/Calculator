using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Xaml.Behaviors;

namespace Calculator.DesktopApplication.Behaviors
{
    [ContentProperty(nameof(ContentTemplateCases))]
    public class ManageContentBehavior : Behavior<ContentControl>
    {
        #region Fields

        private DataTemplate _currentContentTemplate;

        #endregion

        #region Properties

        #region ContentTemplateCases

        public static readonly DependencyProperty ContentTemplateCasesProperty =
            DependencyProperty.Register("ContentTemplateCases", typeof(List<ICase<Size, DataTemplate>>), typeof(ManageContentBehavior),
                                        new PropertyMetadata(new List<ICase<Size, DataTemplate>>(), OnContentTemplateCasesChanged));

        public List<ICase<Size, DataTemplate>> ContentTemplateCases
        {
            get { return (List<ICase<Size, DataTemplate>>) GetValue(ContentTemplateCasesProperty); }
            set { SetValue(ContentTemplateCasesProperty, value); }
        }

        private static void OnContentTemplateCasesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var manageContentBehavior = (ManageContentBehavior) sender;
            manageContentBehavior.OnContentTemplateCasesChanged();
        }

        private void OnContentTemplateCasesChanged()
        {
            UpdateContent();
        }

        #endregion

        #region DefaultContentTemplate

        public static readonly DependencyProperty DefaultContentTemplateProperty =
            DependencyProperty.Register("DefaultContentTemplate", typeof(DataTemplate), typeof(ManageContentBehavior),
                                        new PropertyMetadata(OnDefaultContentTemplateChanged));

        public DataTemplate DefaultContentTemplate
        {
            get { return (DataTemplate) GetValue(DefaultContentTemplateProperty); }
            set { SetValue(DefaultContentTemplateProperty, value); }
        }

        private static void OnDefaultContentTemplateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var manageContentBehavior = (ManageContentBehavior) sender;
            manageContentBehavior.OnDefaultContentTemplateChanged();
        }

        private void OnDefaultContentTemplateChanged()
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
            if (AssociatedObject == null)
                return;

            var suitableContentTemplate = GetSuitableContentTemplate();
            if (ReferenceEquals(suitableContentTemplate, _currentContentTemplate))
                return;

            _currentContentTemplate = suitableContentTemplate;
            AssociatedObject.Content = suitableContentTemplate.LoadContent();
        }

        private DataTemplate GetSuitableContentTemplate()
        {
            var renderSize = AssociatedObject.RenderSize;
            var matchedCase = ContentTemplateCases?.FirstOrDefault(x => x.IsMatched(renderSize));
            if (matchedCase == null)
            {
                return DefaultContentTemplate;
            }

            return matchedCase.Result;
        }
    }
}
