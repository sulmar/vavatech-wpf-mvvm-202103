using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Vavatech.Shop.WpfClient.CustomVisual
{
    // https://docs.microsoft.com/pl-pl/dotnet/desktop/wpf/graphics-multimedia/using-drawingvisual-objects?view=netframeworkdesktop-4.8
    // https://docs.microsoft.com/pl-pl/dotnet/desktop/wpf/advanced/optimizing-performance-2d-graphics-and-imaging?view=netframeworkdesktop-4.8
    public class MyVisualHost : FrameworkElement
    {
        private readonly VisualCollection children;

        public MyVisualHost()
        {
            children = new VisualCollection(this);

            this.Loaded += MyVisualHost_Loaded;

            this.MouseLeftButtonUp += MyVisualHost_MouseLeftButtonUp;
        }

        private void MyVisualHost_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                children.Add(CreateDrawingVisualRectangle(x: random.Next(20, 1200), y: random.Next(10, 1000), size: random.Next(10, 50) ));
            }
        }

        private DrawingVisual CreateDrawingVisualRectangle(double x, double y, double size)
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(x, y), new Size(size, size));

                // Brush brush = new SolidColorBrush(Color.FromUInt32(4278255615u));

                drawingContext.DrawRectangle(Brushes.Blue, new Pen(Brushes.Black, 2), rect);
            } // drawingContext.Close();

            return drawingVisual;
        }

        protected override int VisualChildrenCount => children.Count;

        protected override Visual GetVisualChild(int index)
        {
            return children[index];
        }

        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retrieve the coordinates of the mouse button event.
            System.Windows.Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test by setting up a hit test result callback method.
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Opacity == 1.0)
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 0.4;
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 1.0;
                }
            }

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Stop;
        }
    }
}
