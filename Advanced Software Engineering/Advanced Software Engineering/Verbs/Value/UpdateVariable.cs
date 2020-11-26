namespace Advanced_Software_Engineering.Verbs.Value {

    public class UpdateVariable : IVerb {
        protected Drawer drawer;
        protected string name;
        protected string value;

        public UpdateVariable(Drawer drawer, string name, string value) {
            this.name = name;
            this.value = value;
            this.drawer = drawer;
        }

        public UpdateVariable(Drawer drawer, string name, IValue value) {

        }

        public void ExecuteVerb() {
            IValue variable = drawer.GetVariable(name);
            string type = variable.GetOriginalType();
            drawer.SetVariable(name, ValueFactory.CreateValue(value, type));
        }

        public string GetDescription() {
            return "Updates " + name + " to " + value;
        }
    }
}