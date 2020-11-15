using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// DrawLines IVerb class
    /// </summary>
    public class DrawLines : IVerb {
        private Drawer drawer;
        private Point[] points;

        private bool descCreated = false;
        private string desc;

        /// <summary>
        /// DrawLines constructor
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="points">All of the points to visit</param>
        public DrawLines(Drawer drawer, Point[] points) {
            this.drawer = drawer;
            this.points = points;
        }

        /// <summary>
        /// Draws all the lines
        /// </summary>
        public void ExecuteVerb() {
            drawer.DrawLines(points);
        }

        /// <summary>
        /// Gets description of the command.
        /// </summary>
        /// <returns>What points will be drawn to in what order</returns>
        public string GetDescription() {
            if (!descCreated) {
                desc = "Draws a shape at points: ";

                foreach (Point point in points) {
                    desc += point.X + ", " + point.Y + "\n";
                }
            }
            return desc;
        }
    }
}