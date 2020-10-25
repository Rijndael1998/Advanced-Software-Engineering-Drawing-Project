using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    class DrawLines : Verb {
        Drawer drawer;
        Point[] points;

        bool descCreated = false;
        string desc;

        public DrawLines(Drawer drawer, Point[] points) {
            this.drawer = drawer;
            this.points = points;
        }

        public void ExecuteVerb() {
            drawer.DrawLines(points);
        }

        public string GetDescription() {
            if (!descCreated) {
                desc = "Draws a shape at points: ";

                foreach (Point point in points) {
                    desc += point.X + ", " + point.Y + "\n";
                }
            }
            return desc;
        }
    }
}
