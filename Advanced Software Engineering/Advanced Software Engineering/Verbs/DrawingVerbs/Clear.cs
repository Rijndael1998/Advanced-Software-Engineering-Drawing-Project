using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    public class Clear : Verb {
        Drawer drawer;

        public Clear(Drawer drawer) {
            this.drawer = drawer;
        }

        public void ExecuteVerb() => drawer.ClearCanvas();

        public string GetDescription() {
            return "Clears the canvas";
        }

    }
}
