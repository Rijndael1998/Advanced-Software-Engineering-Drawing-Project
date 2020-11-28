using Advanced_Software_Engineering.Verbs.Value;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {

    /// <summary>
    /// Circle IVerb class.
    /// </summary>
    public class Circle : IVerb {
        private readonly Drawer drawer;
        private readonly IValue scale;

        /// <summary>
        /// Circle constructor creates the Circle IVerb.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">scale of the circle</param>
        public Circle(Drawer drawer, IValue scale) {
            this.drawer = drawer;
            this.scale = scale;
        }

        /// <summary>
        /// Execute the Circle IVerb, which is to draw a circle with the drawer.
        /// </summary>
        public void ExecuteVerb() {
            double scale = this.scale.ToDouble();
            drawer.DrawCircle(scale);
        }

        /// <summary>
        /// Describes how the circle will be drawn.
        /// </summary>
        /// <returns></returns>
        public string GetDescription() {
            return "Draws a circle with a certain radius, with origin of the pen";
        }
    }
}