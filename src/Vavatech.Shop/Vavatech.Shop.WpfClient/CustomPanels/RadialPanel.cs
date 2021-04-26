using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Vavatech.Shop.WpfClient.CustomPanels
{
    public class RadialPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement element in Children)
            {
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0)
                return finalSize;

            double angle = 0;

            double incrementAngle = (360d / Children.Count) * (Math.PI / 180);

            double radiusX = finalSize.Width / 2.4;
            double radiusY = finalSize.Height / 2.4;

            foreach (UIElement element in Children)
            {
                Point childPoint = new Point(Math.Cos(angle) * radiusX, -Math.Sin(angle) * radiusY);

                Point actualChildPoint = new Point(
                    finalSize.Width / 2 + childPoint.X - element.DesiredSize.Width / 2,
                    finalSize.Height / 2 + childPoint.Y - element.DesiredSize.Height / 2
                    );

                element.Arrange(new Rect(actualChildPoint.X, actualChildPoint.Y, element.DesiredSize.Width, element.DesiredSize.Height));

                angle += incrementAngle;

            }

            return finalSize;
        }


    }
}
