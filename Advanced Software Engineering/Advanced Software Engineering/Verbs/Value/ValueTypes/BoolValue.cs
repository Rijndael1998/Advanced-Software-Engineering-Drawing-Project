using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class BoolValue : IValue {

        bool value;
        Type type = typeof(bool);

        public BoolValue(bool value) {
            this.value = value;
        }

        public string GetDescription() {
            return "boolean of value " + value.ToString();
        }

        public Type GetOriginalType() {
            return type;
        }

        public bool ToBool() {
            return value;
        }

        public Color ToColor() {
            return value ? Color.White : Color.Black;
        }

        public double ToDouble() {
            return value ? 1d : 0d;
        }

        public int ToInt() {
            return value ? 1 : 0;
        }
    }
}