using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class ColorValue : IValue {

        Color value;
        Type type = typeof(Color);

        public ColorValue(Color value) {
            this.value = value;
        }

        public string GetDescription() {
            return "A color with description " + value.ToString();
        }

        public Type GetOriginalType() {
            return type;
        }

        public bool ToBool() {
            return value.GetBrightness() > 0.5;
        }

        public Color ToColor() {
            return value;
        }

        public double ToDouble() {
            return value.GetBrightness();
        }

        public int ToInt() {
            return value.ToArgb();
        }
    }
}