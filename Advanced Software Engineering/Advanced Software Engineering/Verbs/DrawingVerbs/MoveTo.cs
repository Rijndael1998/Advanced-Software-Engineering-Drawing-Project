using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// MoveTo IVerb class
    /// </summary>
    public class MoveTo : IVerb {
        private Drawer drawer;
        private Point moveToPoint;

        /// <summary>
        /// Creates a MoveTo instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public MoveTo(Drawer drawer, int x, int y) {
            this.drawer = drawer;
            this.moveToPoint = new Point(x, y);
        }

        /// <summary>
        /// Creates a MoveTo instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point">Point of the position</param>
        public MoveTo(Drawer drawer, Point point) {
            this.drawer = drawer;
            this.moveToPoint = point;
        }

        /// <summary>
        /// Moves the pen to the position
        /// </summary>
        public void ExecuteVerb() {
            this.drawer.MovePen(moveToPoint);
        }

        /// <summary>
        /// Describes where the pen will move.
        /// </summary>
        /// <returns>Description where the pen will move to</returns>
        public string GetDescription() {
            return "Move origin to " + moveToPoint.X + ", " + moveToPoint.Y;
        }
    }
}