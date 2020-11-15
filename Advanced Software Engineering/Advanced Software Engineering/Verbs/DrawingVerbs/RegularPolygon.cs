using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// A class that generates a RegularPolygon IVerb.
    /// </summary>
    public class RegularPolygon : IVerb {
        private Drawer drawer;
        private int sides;
        private double scale;
        private double offset;
        private List<Point> points;

        /// <summary>
        /// Draws a regular polygon.
        /// See <see href="https://en.wikipedia.org/wiki/Regular_polygon"/>.
        /// See also <seealso href="https://www.mathsisfun.com/geometry/regular-polygons.html"/>.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="sides">Number of sides in the regular polygon</param>
        /// <param name="scale">The scale of the regular polygon</param>
        /// <param name="offset">Rotation offset of the regular polygon</param>
        /// <param name="degMode">Default is true. If true, offset is in degrees. If false, offset is in gradians.</param>
        public RegularPolygon(Drawer drawer, int sides, double scale, double offset = 0, bool degMode = true) {
            points = new List<Point>();

            //if in degMode, convert the offset to radians
            if (degMode) offset = Math.PI * offset / 180;

            double constantAngleDelta = 2 * Math.PI / sides;
            for (int side = 0; side < sides; side++) {
                double angle = (constantAngleDelta * side) + offset;

                double dx = scale * Math.Sin(angle);
                double dy = scale * Math.Cos(angle);

                points.Add(new Point((int)Math.Round(dx), (int)Math.Round(dy)));
            }

            this.sides = sides;
            this.scale = scale;
            this.drawer = drawer;
            this.offset = offset;
        }

        /// <summary>
        /// Draws the regular polygons
        /// </summary>
        public void ExecuteVerb() {
            Point currentOrigin = drawer.GetPenPosition();
            List<Point> originShiftedPoints = new List<Point>();
            foreach (Point point in points) originShiftedPoints.Add(new Point(point.X + currentOrigin.X, point.Y + currentOrigin.Y));
            drawer.DrawLines(originShiftedPoints.ToArray());
        }

        /// <summary>
        /// Describes how the regular polygon will be drawn
        /// </summary>
        /// <returns>A description of how the polygon will be drawn</returns>
        public string GetDescription() {
            return "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;
        }
    }
}