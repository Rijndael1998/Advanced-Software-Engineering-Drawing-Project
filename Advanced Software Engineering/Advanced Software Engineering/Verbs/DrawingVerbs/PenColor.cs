using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    class PenColor : Verb {

        Drawer drawer;
        Color color;

        public PenColor(Drawer drawer, Color color) {
            this.drawer = drawer;
            this.color = color;
        }

        public void ExecuteVerb() {
            drawer.SetPenColor(color);
        }

        public string GetDescription() {
            return "Set pen color to: " + color.ToString();
        }
    }
}
