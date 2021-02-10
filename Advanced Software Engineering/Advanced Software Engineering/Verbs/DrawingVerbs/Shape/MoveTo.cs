using Advanced_Software_Engineering.Verbs.Value.ValueObjects;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// MoveTo IVerb class
    /// </summary>
    public class MoveTo : IVerb {
        private readonly Drawer drawer;
        private readonly PointValue moveToPoint;

        /// <summary>
        /// Creates a MoveTo instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="point">Position to move to</param>
        public MoveTo(Drawer drawer, PointValue point) {
            this.drawer = drawer;
            moveToPoint = point;
        }

        /// <summary>
        /// Moves the pen to the position
        /// </summary>
        public void ExecuteVerb() {
            drawer.MovePen(moveToPoint.GetPoint());
        }

        /// <summary>
        /// Describes where the pen will move.
        /// </summary>
        /// <returns>Description where the pen will move to</returns>
        public string GetDescription() {
            return "Move origin";
        }
    }
}