using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class IntValue : IValue {
        private readonly bool initialised = false;

        private readonly int value;

        private bool doubleValueCacheAvaiable = false;
        private double doubleValueCache;

        private bool boolValueCacheAvailable = false;
        private bool boolValueCache;

        private bool colorValueCacheAvailable = false;
        private Color colorValueCache;

        public IntValue(int value) {
            this.value = value;
        }

        public string GetDescription() {
            return "an integer value of " + value;
        }

        public string GetOriginalType() {
            return "int";
        }

        public bool ToBool() {
            if (!boolValueCacheAvailable) {
                boolValueCache = value <= 0;
                boolValueCacheAvailable = true;
            }

            return boolValueCache;
        }

        public Color ToColor() {
            if (!colorValueCacheAvailable) {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                colorValueCache = ValueHelper.IntsToColor(bytes[1], bytes[2], bytes[3], bytes[0]);
                colorValueCacheAvailable = true;
            }
            return colorValueCache;
        }

        public double ToDouble() {
            if (!doubleValueCacheAvaiable) {
                doubleValueCache = value;
                doubleValueCacheAvaiable = true;
            }
            return doubleValueCache;
        }

        public int ToInt() {
            return value;
        }

        public bool isInitialised() {
            return initialised;
        }

        public IValue Clone() {
            return new IntValue(value);
        }
    }
}