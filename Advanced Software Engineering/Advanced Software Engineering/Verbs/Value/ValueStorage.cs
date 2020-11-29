using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {
    public class ValueStorage {

        protected int currentStack;
        protected Dictionary<int,Dictionary<string, IValue>> Variables = new Dictionary<int,Dictionary<string, IValue>>();

        public ValueStorage() {
            Reset();
        }

        public void Reset() {
            Variables.Clear();
            SetStack(0);
        }

        public void Reset(int stack) {
            Variables[stack].Clear();
        }

        public void SetStack(int stack) {
            currentStack = stack;
            if (!Variables.ContainsKey(stack)) Variables.Add(currentStack, new Dictionary<string, IValue>());
        }

        public void SetVariable(string name, int stack, IValue value) {
            Variables[stack][name] = value;
        }

        public void SetVariable(string name, IValue value) {
            SetVariable(name, currentStack, value);
        }

        public IValue GetVariable(string name, int stack) {
            return Variables[stack][name];
        }

        public IValue GetVariable(string name) {
            return GetVariable(name, currentStack);
        }

        public bool CheckVariableExists(string name, int stack) {
            if (name == null) return false;
            return Variables[stack].ContainsKey(name);
        }

        public bool CheckVariableExists(string name) {
            return CheckVariableExists(name, currentStack);
        }
    }
}
