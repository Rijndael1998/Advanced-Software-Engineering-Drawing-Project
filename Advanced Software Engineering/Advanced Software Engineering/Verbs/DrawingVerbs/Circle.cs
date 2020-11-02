using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// Circle Verb class.
    /// </summary>
    public class Circle : Verb {
        Drawer drawer;
        double scale;

        /// <summary>
        /// Circle constructor creates the Circle verb.
        /// </summary>
        /// <param name="drawer">drawer</param>
        /// <param name="scale">scale of the circle</param>
        public Circle(Drawer drawer, double scale) {
            this.drawer = drawer;
            this.scale = scale;
        }

        /// <summary>
        /// Execute the Circle verb, which is to draw a circle with the drawer.
        /// </summary>
        public void ExecuteVerb() {
            drawer.DrawCircle(scale);
        }

        /// <summary>
        /// Describes how the circle will be drawn.
        /// </summary>
        /// <returns></returns>
        public string GetDescription() {
            return "Draws a circle radius " + scale.ToString() + ", with origin of the pen";
        }
    }
}
