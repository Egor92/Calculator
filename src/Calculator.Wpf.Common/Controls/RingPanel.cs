using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calculator.Wpf.Common.Controls
{
	public class RingPanel : Panel
	{
		protected override Size MeasureOverride(Size availableSize)
		{
			if (InternalChildren.Count == 0)
				return base.MeasureOverride(availableSize);

			Size panelDesiredSize = new Size();

			foreach (UIElement child in InternalChildren)
			{
				child.Measure(availableSize);
				panelDesiredSize = child.DesiredSize;
			}

			return panelDesiredSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			if (InternalChildren.Count == 0)
				return finalSize;

			double maxChildDesiredSide = InternalChildren.OfType<UIElement>().Max(x => Math.Max(x.DesiredSize.Height, x.DesiredSize.Width));

			double radius = Math.Min(finalSize.Height, finalSize.Width) / 2 - maxChildDesiredSide / 2;
			double anglePerItem = Math.PI * 2 / InternalChildren.Count;

			for (int i = 0; i < InternalChildren.Count; i++)
			{
				UIElement child = InternalChildren[i];
				Size childSize = child.DesiredSize;

				double itemAngle = anglePerItem * i - Math.PI / 2;
				double x = Math.Cos(itemAngle) * radius + finalSize.Width / 2 - childSize.Width / 2;
				double y = Math.Sin(itemAngle) * radius + finalSize.Height / 2 - childSize.Height / 2;

				Rect rect = new Rect(new Point(x, y), childSize);
				child.Arrange(rect);
			}

			return finalSize;
		}
	}
}
