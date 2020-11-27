using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueObjects;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// DrawTo IVerb class
    /// </summary>
    public class DrawTo : IVerb {
        private readonly Drawer drawer;
        private readonly PointValue moveToPoint;

        /// <summary>
        /// Creates the DrawTo intstance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point">Position to move to</param>
        public DrawTo(Drawer drawer, PointValue point) {
            this.drawer = drawer;
            moveToPoint = point;
        }

        /// <summary>
        /// Draws the line
        /// </summary>
        public void ExecuteVerb() {
            drawer.DrawLine(moveToPoint.GetPoint());
        }

        /// <summary>
        /// Describes how the line is going to be drawn
        /// </summary>
        /// <returns></returns>
        public string GetDescription() {
            return "Draws a line";
        }
    }
}