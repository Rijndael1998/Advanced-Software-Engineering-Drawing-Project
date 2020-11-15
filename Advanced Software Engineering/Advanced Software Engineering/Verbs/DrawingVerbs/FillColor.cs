using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The FillColor Verb class
    /// </summary>
    public class FillColor : Verb {
        private Drawer drawer;
        private Color color;

        /// <summary>
        /// Create the FillColor instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="color">The color of the fill</param>
        public FillColor(Drawer drawer, Color color) {
            this.drawer = drawer;
            this.color = color;
        }

        /// <summary>
        /// Set the fill color
        /// </summary>
        public void ExecuteVerb() {
            drawer.SetFillColor(color);
        }

        /// <summary>
        /// Get description of the color that the drawer will use
        /// </summary>
        /// <returns>Description of the fill color</returns>
        public string GetDescription() {
            return "Set fill color to: " + color.ToString();
        }
    }
}