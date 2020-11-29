using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class UpdateVariable : IVerb {
        protected ValueStorage storage;
        protected string name;
        protected IValue value;

        private void Init(ValueStorage storage, string name, IValue value) {
            this.name = name;
            this.value = value;
            this.storage = storage;
        }

        public UpdateVariable(ValueStorage storage, string name, IValue value) {
            Init(storage, name, value);
        }

        public UpdateVariable(ValueStorage storage, string name, string value) {
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
            if (assignmentStrings.Length == 1) Init(storage, name, ValueFactory.CreateValue(storage, assignmentStrings[0]));
            else if (assignmentStrings.Length == 3) {
                // assignmentStrings looks like this => ["10", "+", "i"]
                IValue value1 = ValueFactory.CreateValue(storage, assignmentStrings[0]);
                string op = assignmentStrings[1];
                IValue value2 = ValueFactory.CreateValue(storage, assignmentStrings[2]);
                Init(storage, name, new ExpressionValue(value1, value2, op));
            }
        }

        public void ExecuteVerb() {
            if (!storage.CheckVariableExists(name)) throw new Exception("Cannot update variable because it is not declared");
            storage.SetVariable(name, value.Clone());
        }

        public string GetDescription() {
            return "Updates " + name + " to " + value;
        }
    }
}