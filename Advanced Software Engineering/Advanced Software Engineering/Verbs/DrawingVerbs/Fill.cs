using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    class Fill : Verb {
        Drawer drawer;
        bool enable;

        public Fill(Drawer drawer, bool enable) {
            this.drawer = drawer;
            this.enable = enable;
        }

        public void ExecuteVerb() {
            if (enable) drawer.EnableFill();
            else drawer.DisableFill();
        }

        public string GetDescription() {
            if (enable) return "Enable fill";
            else return "Disable fill";
        }
    }
}
