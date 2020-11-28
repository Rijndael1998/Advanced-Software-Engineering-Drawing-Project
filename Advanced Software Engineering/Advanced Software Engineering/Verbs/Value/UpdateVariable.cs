using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class UpdateVariable : IVerb {
        protected Drawer drawer;
        protected string name;
        protected IValue value;

        public UpdateVariable(Drawer drawer, string name, IValue value) {
            this.name = name;
            this.value = value;
            this.drawer = drawer;
        }

        public void ExecuteVerb() {
            if (!drawer.CheckVariableExists(name)) throw new Exception("Cannot update variable because it is not declared");
            drawer.SetVariable(name, value);
        }

        public string GetDescription() {
            return "Updates " + name + " to " + value;
        }
    }
}