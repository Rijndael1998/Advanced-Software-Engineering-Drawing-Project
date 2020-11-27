using Advanced_Software_Engineering.Verbs.Value;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// DrawTo IVerb class
    /// </summary>
    public class DrawTo : IVerb {
        private readonly Drawer drawer;
        private readonly IValue moveToPointX;
        private readonly IValue moveToPointY;

        /// <summary>
        /// Creates the DrawTo intstance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="x">X position to move to</param>
        /// <param name="y">Y position to move to</param>
        public DrawTo(Drawer drawer, IValue x, IValue y) {
            this.drawer = drawer;
            moveToPointX = x;
            moveToPointY = y;
        }

        /// <summary>
        /// Draws the line
        /// </summary>
        public void ExecuteVerb() {
            drawer.DrawLine(new Point(moveToPointX.ToInt(), moveToPointY.ToInt()));
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