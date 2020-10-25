using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    public class FillColor : Verb {

        Drawer drawer;
        Color color;

        public FillColor(Drawer drawer, Color color) {
            this.drawer = drawer;
            this.color = color;
        }

        public void ExecuteVerb() {
            drawer.SetFillColor(color);
        }

        public string GetDescription() {
            return "Set fill color to " + color.ToString();
        }

    }
}
