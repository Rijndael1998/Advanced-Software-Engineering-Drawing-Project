using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// Rectangle IVerb class
    /// </summary>
    /// <todo>
    /// Correct
    /// </todo>
    public class Rectangle : IVerb {
        private readonly Drawer drawer;
        private readonly PointF[] points;

        private readonly double width;
        private readonly double height;

        /// <summary>
        /// Create a rectangle instance. Makes sure that
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="width">rectangle width</param>
        /// <param name="height">rectangle height</param>
        public Rectangle(Drawer drawer, double width, double height) {
            this.drawer = drawer;

            float root2 = (float)Math.Sqrt(2) / 2;

            points = new PointF[]
            {
                new PointF((float) -width * root2,    (float) -height * root2),
                new PointF((float) width * root2,     (float) -height * root2),
                new PointF((float) width * root2,     (float) height * root2),
                new PointF((float) -width * root2,    (float) height * root2)
            };

            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets the description from the rectangle
        /// </summary>
        /// <returns>Describes the rectangle</returns>
        public string GetDescription() {
            return "Draws a rectangle with the width of" + width + " and the height of " + height + " with the pen in the center";
        }

        /// <summary>
        /// Draws the rectangle
        /// </summary>
        public void ExecuteVerb() {
            //adjust for current pen position
            Point position = drawer.GetPenPosition();

            List<Point> morePoints = new List<Point>();

            foreach (PointF point in points) {
                morePoints.Add(new Point((int)(point.X + position.X), (int)(point.Y + position.Y)));
            }

            drawer.DrawLines(morePoints.ToArray());
        }
    }
}