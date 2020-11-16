using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class IntValue : IValue {

        int value;

        bool doubleValueCacheAvaiable = false;
        double doubleValueCache;

        bool boolValueCacheAvailable = false;
        bool boolValueCache;

        bool colorValueCacheAvailable = false;
        Color colorValueCache;

        Type type = typeof(int);

        public IntValue(int value) {
            this.value = value;
        }

        public string GetDescription() {
            return "an integer value of " + value;
        }

        public Type GetOriginalType() {
            return type;
        }

        public bool ToBool() {
            if(!boolValueCacheAvailable) {
                boolValueCache = value <= 0;
                boolValueCacheAvailable = true;
            }

            return boolValueCache;
        }

        public Color ToColor() {
            if(!colorValueCacheAvailable) {
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
    }
}