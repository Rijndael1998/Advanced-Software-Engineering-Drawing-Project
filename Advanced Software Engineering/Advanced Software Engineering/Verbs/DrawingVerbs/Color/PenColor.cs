using Advanced_Software_Engineering.Verbs.Value;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The PenColor IVerb class
    /// </summary>
    public class PenColor : IVerb {
        private readonly Drawer drawer;
        private readonly IValue color;

        /// <summary>
        /// Creates a PenColor instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="color">Pen color</param>
        public PenColor(Drawer drawer, IValue color) {
            this.drawer = drawer;
            this.color = color;
        }

        /// <summary>
        /// Sets the pen color
        /// </summary>
        public void ExecuteVerb() {
            drawer.SetPenColor(color.ToColor());
        }

        /// <summary>
        /// Describes the pen color
        /// </summary>
        /// <returns>The description pen color</returns>
        public string GetDescription() {
            return "Set pen color";
        }
    }
}