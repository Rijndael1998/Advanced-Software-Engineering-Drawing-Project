using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class ColorValue : IValue {
        private bool initialised = false;

        private Color value;
        private Type type = typeof(Color);

        public ColorValue(Color value) {
            this.value = value;
            initialised = true;
        }

        public ColorValue() {
        }

        public string GetDescription() {
            if (initialised) return "A color with description " + value.ToString();
            else return "An uninitialised color";
        }

        public string GetOriginalType() {
            return "color";
        }

        public bool ToBool() {
            return ToColor().GetBrightness() > 0.5;
        }

        public Color ToColor() {
            if (initialised) return value;
            else throw new Exception("Color value not set");
        }

        public double ToDouble() {
            return ToColor().GetBrightness();
        }

        public int ToInt() {
            return ToColor().ToArgb();
        }

        public bool isInitialised() {
            return initialised;
        }
    }
}