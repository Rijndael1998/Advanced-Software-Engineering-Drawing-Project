using Advanced_Software_Engineering.Verbs.Value.ValueObjects;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// DrawLines IVerb class
    /// </summary>
    public class DrawLines : IVerb {
        private readonly Drawer drawer;
        private readonly PointValue[] points;

        /// <summary>
        /// DrawLines constructor
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="points">All of the points to visit</param>
        public DrawLines(Drawer drawer, PointValue[] points) {
            this.drawer = drawer;
            this.points = points;
        }

        /// <summary>
        /// Draws all the lines
        /// </summary>
        public void ExecuteVerb() {
            List<Point> pointList = new List<Point>();
            foreach (PointValue pointValue in points) pointList.Add(pointValue.GetPoint());
            drawer.DrawLines(pointList.ToArray());
        }

        /// <summary>
        /// Gets description of the command.
        /// </summary>
        /// <returns>A generic description of the command</returns>
        public string GetDescription() {
            return "Draws a shape at specific points.";
        }
    }
}