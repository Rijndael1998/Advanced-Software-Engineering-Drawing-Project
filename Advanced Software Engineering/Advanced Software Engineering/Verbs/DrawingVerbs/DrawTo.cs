using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// DrawTo Verb class
    /// </summary>
    public class DrawTo : Verb {

        Drawer drawer;
        Point moveToPoint;

        /// <summary>
        /// Creates the DrawTo intstance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="x">X position to move to</param>
        /// <param name="y">Y position to move to</param>
        public DrawTo(Drawer drawer, int x, int y) {
            this.drawer = drawer;
            moveToPoint = new Point(x, y);
        }

        /// <summary>
        /// Draws the line
        /// </summary>
        public void ExecuteVerb() {
            drawer.DrawLine(moveToPoint);
        }

        /// <summary>
        /// Describes how the line is going to be drawn
        /// </summary>
        /// <returns></returns>
        public string GetDescription() {
            return "Draw line " + moveToPoint.X + ", " + moveToPoint.Y;
        }
    }
}
