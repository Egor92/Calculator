using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Calculator.Wpf.Common.Xaml
{
    [ContentProperty(nameof(TemplatesByType))]
    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        public IDictionary TemplatesByType { get; set; } = new Dictionary<Type, DataTemplate>();

        public DataTemplate DefaultTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null || TemplatesByType == null)
                return DefaultTemplate;

            var itemType = item.GetType();

            foreach (var key in TemplatesByType.Keys)
            {
                var type = key as Type;
                var dataTemplate = TemplatesByType[key] as DataTemplate;

                if (type == null || dataTemplate == null)
                    continue;

                if (itemType == type)
                    return dataTemplate;
            }

            foreach (var key in TemplatesByType.Keys)
            {
                var type = key as Type;
                var dataTemplate = TemplatesByType[key] as DataTemplate;

                if (type == null || dataTemplate == null)
                    continue;

                if (type.IsAssignableFrom(itemType))
                    return dataTemplate;
            }

            return DefaultTemplate;
        }
    }
}
