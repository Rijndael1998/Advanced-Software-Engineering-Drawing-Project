using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.DrawingVerbs {
    public class Triangle : Verb {
        Verb verb;

        public Triangle(Drawer drawer, double scale) {
            verb = new RegularPolygon(drawer, 3, scale);
        }

        public Triangle(Drawer drawer, double scale, double offset) {
            verb = new RegularPolygon(drawer, 3, scale, offset);
        }

        public Triangle(Drawer drawer, Point point1, Point point2, Point point3) {
            verb = new DrawLines(drawer, new Point[] { point1, point2, point3 });
        }

        public void ExecuteVerb() => verb.ExecuteVerb();

        public string GetDescription() => verb.GetDescription();
    }
}
