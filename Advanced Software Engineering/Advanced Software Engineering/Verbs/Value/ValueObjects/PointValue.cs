using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueObjects {

    public class PointValue {
        private readonly IValue x;
        private readonly IValue y;

        public PointValue(IValue x, IValue y) {
            this.x = x;
            this.y = y;
        }

        public PointValue(ValueStorage storage, string parameter1, string parameter2) {
            x = ValueFactory.CreateValue(storage, parameter1);
            y = ValueFactory.CreateValue(storage, parameter2);
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