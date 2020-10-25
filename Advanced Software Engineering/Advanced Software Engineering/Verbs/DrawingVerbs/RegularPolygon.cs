using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// A class that generates a RegularPolygon verb. 
    /// </summary>
    public class RegularPolygon : Verb {
        protected Drawer drawer;
        protected int sides;
        protected double scale;
        protected double offset;
        List<Point> points;

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

        public void ExecuteVerb() {
            Point currentOrigin = drawer.GetPenPosition();
            List<Point> originShiftedPoints = new List<Point>();
            foreach (Point point in points) originShiftedPoints.Add(new Point(point.X + currentOrigin.X, point.Y + currentOrigin.Y));
            drawer.DrawLines(originShiftedPoints.ToArray());
        }

        public string GetDescription() {
            return "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;
        }
    }
}
