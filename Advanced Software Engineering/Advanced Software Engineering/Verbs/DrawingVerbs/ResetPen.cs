using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    public class ResetPen : Verb {
        Drawer drawer;

        public ResetPen(Drawer drawer) {
            this.drawer = drawer;
        }

        public void ExecuteVerb() => drawer.MovePen(new System.Drawing.Point(0, 0));

        public string GetDescription() {
            return "Moves pen to the start";
        }

    }
}
