using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.Value_Objects {

    public class PointValue {
        private IValue x;
        private IValue y;

        public PointValue(int x, int y) {
            this.x = new IntValue(x);
            this.y = new IntValue(y);
        }

        public PointValue(IValue x, IValue y) {
            this.x = x;
            this.y = y;
        }

        public int GetX() {
            return x.ToInt();
        }

        public int GetY() {
            return y.ToInt();
        }
    }
}