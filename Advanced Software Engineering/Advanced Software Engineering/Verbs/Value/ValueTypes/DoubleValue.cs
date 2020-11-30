using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class DoubleValue : IValue {
        private readonly bool initialised = false;

        private bool colorValueCacheAvailable = false;
        private Color colorValueCache;

        private readonly double value;

        public DoubleValue(double value) {
            this.value = value;
        }

        public string GetDescription() {
            return "an double value of " + value;
        }

        public string GetOriginalType() {
            return "double";
        }

        public bool ToBool() {
            return value > 0;
        }

        public Color ToColor() {
            if (!colorValueCacheAvailable) {
                int i = (int)Math.Round(value * 255);
                i = Math.Min(255, i);
                if (i < 0) i = 0;
                colorValueCache = ValueHelper.IntsToColor(i, i, i);
                colorValueCacheAvailable = true;
            }
            return colorValueCache;
        }

        public double ToDouble() {
            return value;
        }

        public int ToInt() {
            return (int)Math.Round(value);
        }

        public bool isInitialised() {
            return initialised;
        }

        public IValue Clone() {
            return new DoubleValue(value);
        }
    }
}