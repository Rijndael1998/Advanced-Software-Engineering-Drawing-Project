using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    /// <summary>
    /// The Clear Verb class.
    /// </summary>
    public class Clear : Verb {
        Drawer drawer;

        /// <summary>
        /// Create the clear Verb
        /// </summary>
        /// <param name="drawer"></param>
        public Clear(Drawer drawer) {
            this.drawer = drawer;
        }

        /// <summary>
        /// Execute the clear verb. It clears the drawer.
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
