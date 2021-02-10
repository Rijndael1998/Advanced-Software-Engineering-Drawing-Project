namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// Setsets the pen to the initial position.
    /// </summary>
    public class ResetPen : IVerb {
        private readonly Drawer drawer;

        /// <summary>
        /// Creates the ResetPen IVerb
        /// </summary>
        /// <param name="drawer">drawer</param>
        public ResetPen(Drawer drawer) {
            this.drawer = drawer;
        }

        /// <summary>
        /// Moves the pen to 0, 0
        /// </summary>
        public void ExecuteVerb() => drawer.MovePen(new System.Drawing.Point(0, 0));

        /// <summary>
        /// Gets the description of the command.
        /// </summary>
        /// <returns>The description of the command</returns>
        public string GetDescription() {
            return "Moves pen to the start (0, 0)";
        }
    }
}