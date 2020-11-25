using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class DoubleValue : IValue {

        bool initialised = false;

        bool colorValueCacheAvailable = false;
        Color colorValueCache;

        double value;
        Type type = typeof(double);

        public DoubleValue(double value) {
            this.value = value;
        }

        public string GetDescription() {
            return "an double value of " + value;
        }

        public Type GetOriginalType() {
            return type;
        }

        public bool ToBool() {
            return value > 0.5;
        }

        public Color ToColor() {
            if(!colorValueCacheAvailable) {
                int i = (int) Math.Round(value * 255);
                i = Math.Max(255, i);
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
    }
}