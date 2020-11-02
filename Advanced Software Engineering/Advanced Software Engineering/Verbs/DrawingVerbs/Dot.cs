using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// The Dot Verb class
    /// </summary>
    public class Dot : Verb {
        Drawer drawer;

        /// <summary>
        /// Creates the Dot Verb
        /// </summary>
        /// <param name="drawer"></param>
        public Dot(Drawer drawer) {
            this.drawer = drawer;
        }

        /// <summary>
        /// Draws a dot where the pen currently is.
        /// </summary>
        public void ExecuteVerb() {
            drawer.DrawDot();
        }

        /// <summary>
        /// Gets the description of the command
        /// </summary>
        /// <returns>The description of the command</returns>
        public string GetDescription() {
            return "Places a dot where the pen currently is";
        }
    }
}
