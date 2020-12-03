using System;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {
    public class ValueStorage {

        protected int currentStack;
        protected Dictionary<int, Dictionary<string, IValue>> Variables = new Dictionary<int, Dictionary<string, IValue>>();

        public ValueStorage() {
            Reset();
        }

        public void Reset() {
            Variables = new Dictionary<int, Dictionary<string, IValue>>();
            SetStack(0);
        }

        private void SetStack(int stack) {
            if (stack < 0) throw new Exception("Stack cannot be less than 0");

            if (!Variables.ContainsKey(stack)) Variables.Add(currentStack, new Dictionary<string, IValue>());
        }

        public void IncreaseStack() {
            currentStack++;
            SetStack(currentStack);
        }

        public void DecreaseStack() {
            if (currentStack > 0) {
                Variables.Remove(currentStack);
                currentStack--;
                SetStack(currentStack);
            }
        }

        private void SetVariable(string name, int stack, IValue value) {
            for (int internalStack = stack; internalStack >= 0; internalStack--) {
                if (value == null || CheckVariableExists(name, internalStack)) {
                    Variables[internalStack][name] = value;
                    return;
                }
            }
            Variables[stack][name] = value;
        }

        public void SetVariable(string name, IValue value) {
            SetVariable(name, currentStack, value);
        }

        private IValue GetVariable(string name, int stack) {
            return Variables[stack][name];
        }

        public IValue GetVariable(string name) {
            for (int stack = currentStack; stack >= 0; stack--) {
                if (CheckVariableExists(name, stack)) return GetVariable(name, stack);
            }
            throw new Exception("Cannot find variable " + name);
        }

        private bool CheckVariableExists(string name, int stack) {
            if (name == null) return false;
            return Variables[stack].ContainsKey(name);
        }

        public bool CheckVariableExists(string name) {
            if (name == null) return false;
            for (int stack = currentStack; stack >= 0; stack--) {
                if (CheckVariableExists(name, stack)) return true;
            }
            return false;
        }
    }
}
