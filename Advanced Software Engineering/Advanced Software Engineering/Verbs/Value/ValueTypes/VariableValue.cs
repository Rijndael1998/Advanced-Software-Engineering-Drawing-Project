using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    public class VariableValue : IValue {
        private Drawer drawer;
        private string variableName;

        public VariableValue(Drawer drawer, string variableName) {
            this.variableName = variableName;
            if (!drawer.CheckVariableExists(variableName)) throw new Exception("Tried to access " + variableName + " before it was assigned. ");
            this.drawer = drawer;
        }

        private IValue get() {
            return drawer.GetVariable(variableName);
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
    }
}