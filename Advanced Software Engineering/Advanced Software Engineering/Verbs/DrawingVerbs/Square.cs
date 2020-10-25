using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    class Square : Verb {

        Verb verb;

        public Square(Drawer drawer, double scale) {
            verb = new RegularPolygon(drawer, 4, scale);
        }

        public Square(Drawer drawer, double scale, double offset) {
            verb = new RegularPolygon(drawer, 4, scale, offset);
        }

        public void ExecuteVerb() => verb.ExecuteVerb();

        public string GetDescription() => verb.GetDescription();
    }
}
