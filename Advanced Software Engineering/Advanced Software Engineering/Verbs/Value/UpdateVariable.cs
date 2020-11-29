using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class UpdateVariable : IVerb {
        protected Drawer drawer;
        protected string name;
        protected IValue value;

        private void Init(Drawer drawer, string name, IValue value) {
            this.name = name;
            this.value = value;
            this.drawer = drawer;
        }

        public UpdateVariable(Drawer drawer, string name, IValue value) {
            Init(drawer, name, value);
        }

        public UpdateVariable(Drawer drawer, string name, string value) {
            // incoming values look something like this "= 10"
            // or "= 10 + i"

            //seperate assignment characters from everything else
            foreach (string op in new string[] { "=", "+", "-", "*", "/" }) {
                value = value.Replace(op, " " + op + " ");
            }

            value = HelperFunctions.Strip(value);
            if (value[0] == "="[0]) {
                value = value.Substring(1);
            }
            // now will definitly look like this:
            // 10 + i or i

            string[] assignmentStrings = HelperFunctions.StripStringArray(value.Split(" "[0])).ToArray();

            // assignmentStrings will look something like this:
            // ["i"] or ["10", "+", "i"]
            if (assignmentStrings.Length == 1) Init(drawer, name, ValueFactory.CreateValue(drawer, assignmentStrings[0]));
            else if (assignmentStrings.Length == 3) {
                // assignmentStrings looks like this => ["10", "+", "i"]
                IValue value1 = ValueFactory.CreateValue(drawer, assignmentStrings[0]);
                string op = assignmentStrings[1];
                IValue value2 = ValueFactory.CreateValue(drawer, assignmentStrings[2]);
                Init(drawer, name, new ExpressionValue(value1, value2, op));
            }
        }

        public void ExecuteVerb() {
            if (!drawer.CheckVariableExists(name)) throw new Exception("Cannot update variable because it is not declared");
            drawer.SetVariable(name, value.Clone());
        }

        public string GetDescription() {
            return "Updates " + name + " to " + value;
        }
    }
}