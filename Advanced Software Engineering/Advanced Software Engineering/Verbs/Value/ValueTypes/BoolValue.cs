using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class BoolValue : IValue {

        bool initialised = false;

        bool value;
        Type type = typeof(bool);

        public BoolValue(bool value) {
            this.value = value;
            initialised = true;
        }

        public BoolValue() {
        }

        public string GetDescription() {
            if (initialised) return "boolean of value " + value.ToString();
            else return "an unset boolean value";
        }

        public Type GetOriginalType() {
            return type;
        }

        public bool ToBool() {
            if (initialised) return value;
            else throw new Exception("not initilised");
        }

        public Color ToColor() {
            return ToBool() ? Color.White : Color.Black;
        }

        public double ToDouble() {
            return ToBool() ? 1d : 0d;
        }

        public int ToInt() {
            return ToBool() ? 1 : 0;
        }

        public bool isInitialised() {
            return initialised;
        }
    }
}