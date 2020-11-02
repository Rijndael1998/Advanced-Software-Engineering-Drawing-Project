using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// Rectangle Verb class
    /// </summary>
    /// <todo>
    /// Correct
    /// </todo>
    public class Rectangle : Verb {
        Verb verb;

        Drawer drawer;
        List<Point> points;
        bool correctForOrigin;

        /// <summary>
        /// Create a rectangle instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="width">rectangle width</param>
        /// <param name="height">rectangle height</param>
        /// <param name="center">weather to center the rectangle on the pen</param>
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

        /// <summary>
        /// Create a rectangle instance
        /// </summary>
        /// <remarks>
        /// Unlike the above, this instance creates points based on widths and heights of the two points
        /// </remarks>
        /// <param name="drawer">drawer</param>
        /// <param name="point1">point spawn</param>
        /// <param name="point2">point spawn</param>
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

        /// <summary>
        /// Gets the description from the rectangle
        /// </summary>
        /// <returns>Describes the rectangle</returns>
        public string GetDescription() {
            return "";
        }

        /// <summary>
        /// Draws the rectangle
        /// </summary>
        public void ExecuteVerb() => drawer.DrawLines(points.ToArray());

    }
}
