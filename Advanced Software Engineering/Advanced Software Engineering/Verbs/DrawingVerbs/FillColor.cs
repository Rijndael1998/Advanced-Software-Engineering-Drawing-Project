using Advanced_Software_Engineering.Verbs.Value;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// The FillColor IVerb class
    /// </summary>
    public class FillColor : IVerb {
        private readonly Drawer drawer;
        private readonly IValue color;

        /// <summary>
        /// Create the FillColor instance
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="color">The color of the fill</param>
        public FillColor(Drawer drawer, IValue color) {
            this.drawer = drawer;
            this.color = color;
        }

        /// <summary>
        /// Set the fill color
        /// </summary>
        public void ExecuteVerb() {
            drawer.SetFillColor(color.ToColor());
        }

        /// <summary>
        /// Get description of the color that the drawer will use
        /// </summary>
        /// <returns>Description of the fill color</returns>
        public string GetDescription() {
            return "Set fill color to the specified color";
        }
    }
}