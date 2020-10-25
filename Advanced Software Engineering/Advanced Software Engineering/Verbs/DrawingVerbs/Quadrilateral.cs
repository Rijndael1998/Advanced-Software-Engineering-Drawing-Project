using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    class Quadrilateral : Verb {
        Verb verb;

        bool descCreated = false;
        string desc;

        public Quadrilateral(Drawer drawer, Point point1, Point point2, Point point3, Point point4) {
            verb = new DrawLines(drawer, new Point[] { point1, point2, point3, point4 });
        }

        public void ExecuteVerb() => verb.ExecuteVerb();

        public string GetDescription() => verb.GetDescription();
    }
}
