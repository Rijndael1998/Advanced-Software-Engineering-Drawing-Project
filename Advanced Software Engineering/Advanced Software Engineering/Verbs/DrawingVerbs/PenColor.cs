using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The PenColor Verb class
    /// </summary>
    public class PenColor : Verb {
        private Drawer drawer;
        private Color color;

        /// <summary>
        /// Creates a PenColor instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="color">Pen color</param>
        public PenColor(Drawer drawer, Color color) {
            this.drawer = drawer;
            this.color = color;
        }

        /// <summary>
        /// Sets the pen color
        /// </summary>
        public void ExecuteVerb() {
            drawer.SetPenColor(color);
        }

        /// <summary>
        /// Describes the pen color
        /// </summary>
        /// <returns>The description pen color</returns>
        public string GetDescription() {
            return "Set pen color to: " + color.ToString();
        }
    }
}