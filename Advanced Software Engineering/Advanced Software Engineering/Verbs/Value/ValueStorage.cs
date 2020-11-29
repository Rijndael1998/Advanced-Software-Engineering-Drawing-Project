using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {
    public class ValueStorage {

        protected Dictionary<string, IValue> Variables = new Dictionary<string, IValue>();

        public ValueStorage() {
            Reset();
        }

        public void Reset() {
            Variables.Clear();
        }

        public void SetVariable(string name, IValue value) {
            Variables[name] = value;
        }

        public IValue GetVariable(string name) {
            return Variables[name];
        }

        public bool CheckVariableExists(string name) {
            if (name == null) return false;
            return Variables.ContainsKey(name);
        }
    }
}
