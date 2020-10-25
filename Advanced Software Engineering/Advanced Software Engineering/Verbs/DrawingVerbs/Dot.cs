using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    public class Dot : Verb {
        Drawer drawer;
        public Dot(Drawer drawer) {
            this.drawer = drawer;
        }

        public void ExecuteVerb() {
            drawer.DrawDot();
        }

        public string GetDescription() {
            return "Places a dot where the pen currently is";
        }
    }
}
