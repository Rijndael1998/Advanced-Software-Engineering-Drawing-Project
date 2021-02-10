using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    internal class BoolValue : IValue {
        private readonly bool initialised = false;

        private readonly bool value;

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

        public string GetOriginalType() {
            return "bool";
        }

        public bool ToBool() {
            if (initialised) return value;
            else throw new Exception("Not initilised");
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

        public bool IsInitialised() {
            return initialised;
        }

        public IValue Clone() {
            return new BoolValue(value);
        }
    }
}