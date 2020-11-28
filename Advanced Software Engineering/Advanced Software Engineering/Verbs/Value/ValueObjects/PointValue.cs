using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueObjects {

    public class PointValue {
        private IValue x;
        private IValue y;

        public PointValue(IValue x, IValue y) {
            this.x = x;
            this.y = y;
        }

        public PointValue(Drawer drawer, string parameter1, string parameter2) {
            x = ValueFactory.CreateValue(drawer, parameter1);
            y = ValueFactory.CreateValue(drawer, parameter2);
        }

        public PointValue(string parameter1, string parameter2) {
            x = ValueFactory.CreateValue(parameter1, "int");
            y = ValueFactory.CreateValue(parameter2, "int");
        }

        public int GetX() {
            return x.ToInt();
        }

        public int GetY() {
            return y.ToInt();
        } 

        public Point GetPoint() {
            return new Point(GetX(), GetY());
        }
    }
}