using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueObjects {

    internal class ColorValue : IValue {
        private readonly IValue r;
        private readonly IValue g;
        private readonly IValue b;

        private readonly bool hasAlpha;
        private readonly IValue a;

        public ColorValue(Color value) {
            r = new IntValue(value.R);
            g = new IntValue(value.G);
            b = new IntValue(value.B);
            a = new IntValue(value.A);
            hasAlpha = true;
        }

        public ColorValue(IValue r, IValue g, IValue b, IValue a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
            hasAlpha = true;
        }

        public ColorValue(IValue r, IValue g, IValue b) {
            this.r = r;
            this.g = g;
            this.b = b;
            hasAlpha = false;
        }

        public string GetDescription() {
            return "A color value";
        }

        public string GetOriginalType() {
            return "color";
        }

        public bool ToBool() {
            return ToColor().GetBrightness() > 0.5;
        }

        public Color ToColor() {
            if (hasAlpha) return Color.FromArgb(a.ToInt(), r.ToInt(), g.ToInt(), b.ToInt());
            else return Color.FromArgb(r.ToInt(), g.ToInt(), b.ToInt());
        }

        public double ToDouble() {
            return ToColor().GetBrightness();
        }

        public int ToInt() {
            return ToColor().ToArgb();
        }

        public bool IsInitialised() {
            return true;
        }

        public IValue Clone() {
            return new ColorValue(this.ToColor());
        }
    }
}