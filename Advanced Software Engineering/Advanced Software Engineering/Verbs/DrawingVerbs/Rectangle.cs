using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    //TODO: correct
    class Rectangle : Verb {
        Verb verb;

        Drawer drawer;
        List<Point> points;
        bool correctForOrigin;

        public Rectangle(Drawer drawer, double width, double height, bool center = true) {
            this.drawer = drawer;
            correctForOrigin = true;

            PointF[] points = new PointF[]
            {
                new PointF((float) -width,    (float) -height),
                new PointF((float) width,     (float) -height),
                new PointF((float) width,     (float) height),
                new PointF((float) -width,    (float) height)
            };

            this.points = new List<Point>();
            foreach (PointF pointF in points) this.points.Add(new Point((int)Math.Round(pointF.X), (int)Math.Round(pointF.Y)));
        }

        public Rectangle(Drawer drawer, Point point1, Point point2) {
            this.drawer = drawer;

            PointF[] points = new PointF[]
            {
                new PointF((float) point1.X,    (float) point1.Y),
                new PointF((float) point1.X,    (float) point2.Y),
                new PointF((float) point2.X,    (float) point2.Y),
                new PointF((float) point2.X,    (float) point1.Y)
            };

            this.points = new List<Point>();
            foreach (PointF pointF in points) this.points.Add(new Point((int)Math.Round(pointF.X), (int)Math.Round(pointF.Y)));

            correctForOrigin = false;

        }

        public string GetDescription() {
            return "";
        }

        public void ExecuteVerb() => drawer.DrawLines(points.ToArray());

    }
}
