namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The Clear IVerb class.
    /// </summary>
    public class Clear : IVerb {
        private Drawer drawer;

        /// <summary>
        /// Create the clear IVerb
        /// </summary>
        /// <param name="drawer"></param>
        public Clear(Drawer drawer) {
            this.drawer = drawer;
        }

        /// <summary>
        /// Execute the clear IVerb. It clears the drawer.
        /// </summary>
        public void ExecuteVerb() => drawer.ClearCanvas();

        /// <summary>
        /// Describes the clearing.
        /// </summary>
        /// <returns>A description of clearing</returns>
        public string GetDescription() {
            return "Clears the canvas";
        }
    }
}