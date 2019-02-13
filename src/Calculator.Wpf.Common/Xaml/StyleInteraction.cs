using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;

namespace Calculator.Wpf.Common.Xaml
{
    public class BehaviorCollection : List<Behavior>
    {
        
    }

    public static class StyleInteraction
    {
        #region Behaviors

        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached("Behaviors", typeof(BehaviorCollection), typeof(StyleInteraction),
                                                new PropertyMetadata(OnBehaviorsChanged));

        public static void SetBehaviors(DependencyObject element, BehaviorCollection value)
        {
            element.SetValue(BehaviorsProperty, value);
        }

        public static BehaviorCollection GetBehaviors(DependencyObject element)
        {
            return (BehaviorCollection) element.GetValue(BehaviorsProperty);
        }

        private static void OnBehaviorsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is BehaviorCollection newBehaviors))
                return;

            var clonedNewBehaviors = newBehaviors.Select(x => x.Clone())
                                                 .OfType<Behavior>()
                                                 .ToList();

            var behaviors = Interaction.GetBehaviors(sender);
            foreach (var clonedNewBehavior in clonedNewBehaviors)
            {
                behaviors.Add(clonedNewBehavior);
            }
        }

        #endregion
    }
}
