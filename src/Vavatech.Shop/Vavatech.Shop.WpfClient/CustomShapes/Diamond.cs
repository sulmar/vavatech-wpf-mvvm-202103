using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Vavatech.Shop.WpfClient.CustomShapes
{
    // https://markheath.net/post/creating-resizable-shape-controls-in
    public class Diamond : Shape
    {
        public enum Orientation
        {
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW
        }

        public Orientation TriangleOrientation
        {
            get { return (Orientation)GetValue(TriangleOrientationProperty); }
            set { SetValue(TriangleOrientationProperty, value); }
        }


        // Using a DependencyProperty as the backing store for TriangleOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TriangleOrientationProperty =
            DependencyProperty.Register("TriangleOrientation", typeof(Orientation), typeof(Diamond), new UIPropertyMetadata(Orientation.N, OnOrientationChanged));

        private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs ek)
        {
            Diamond t = (Diamond)d;

            t.InvalidateVisual(); // Wywoła metodę DefiningGeometry
        }

        public Diamond()
        {
            this.Stretch = System.Windows.Media.Stretch.Fill;
        }

        protected override Geometry DefiningGeometry => MyGeometry();

        private Geometry MyGeometry()
        {
            // return Geometry.Parse("M 10,100 C 10,300 300,-200 300,100");

            string data;

            if (TriangleOrientation == Orientation.N)
                data = "M 0,1 l 1,1 h -2 Z";
            else if (TriangleOrientation == Orientation.NE)
                data = "M 0,0 h 1 v 1 Z";
            else if (TriangleOrientation == Orientation.E)
                data = "M 0,0 l 1,1 l -1,1 Z";
            else if (TriangleOrientation == Orientation.SE)
                data = "M 1,0 v 1 h -1 Z";
            else if (TriangleOrientation == Orientation.S)
                data = "M 0,0 h 2 l -1,1 Z";
            else if (TriangleOrientation == Orientation.SW)
                data = "M 0,0 v 1 h 1 Z";
            else if (TriangleOrientation == Orientation.W)
                data = "M 0,1 l 1,1 v -2 Z";
            else
                data = "M 0,0 h 1 l -1,1 Z";

            return Geometry.Parse(data);
        }
    }
}
