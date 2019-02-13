using System;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;
using Calculator.DesktopApplication.Interactions.Notifications;
using Calculator.Wpf.Common.Controls;
using Prism.Interactivity.InteractionRequest;

namespace Calculator.DesktopApplication.Interactions.Actions
{
    public class TurnTelephoneTriggerAction : TriggerAction<RingPanel>
    {
        protected override void Invoke(object parameter)
        {
            if (!(parameter is InteractionRequestedEventArgs args))
                return;

            if (!(args.Context is TurnTelephoneNotification notification))
                return;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0.0,
                To = notification.Angle,
                Duration = TimeSpan.FromSeconds(0.6 * Math.Pow(1.1, notification.Index)),
                EasingFunction = new SineEase(),
                AutoReverse = true,
            };
            AssociatedObject.BeginAnimation(RingPanel.FirstItemAngleProperty, animation);
        }
    }
}
