using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    class Circle : Verb {
        Drawer drawer;
        double scale;

        public Circle(Drawer drawer, double scale) {
            this.drawer = drawer;
            this.scale = scale;
        }

        public void ExecuteVerb() {
            drawer.DrawCircle(scale);
        }

        public string GetDescription() {
            return "Draws a circle radius " + scale.ToString() + ", with origin of the pen";
        }
    }
}
