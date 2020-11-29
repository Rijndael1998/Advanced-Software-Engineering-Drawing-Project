using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    public class VariableValue : IValue {
        private readonly ValueStorage storage;
        private readonly string variableName;

        public VariableValue(ValueStorage storage, string variableName) {
            this.variableName = variableName;
            if (!storage.CheckVariableExists(variableName)) throw new Exception("Tried to access " + variableName + " before it was assigned. ");
            this.storage = storage;
        }

        private IValue get() {
            return storage.GetVariable(variableName);
        }

        public string GetDescription() {
            return get().GetDescription();
        }

        public string GetOriginalType() {
            return get().GetOriginalType();
        }

        public bool isInitialised() {
            return get().isInitialised();
        }

        public bool ToBool() {
            return get().ToBool();
        }

        public Color ToColor() {
            return get().ToColor();
        }

        public double ToDouble() {
            return get().ToDouble();
        }

        public int ToInt() {
            return get().ToInt();
        }

        public IValue Clone() {
            return new VariableValue(storage, variableName);
        }
    }
}