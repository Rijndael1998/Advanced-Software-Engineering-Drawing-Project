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

        public void SetStack(int stack) {
            currentStack = stack < 0 ? 0 : stack;
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

        public void SetVariable(string name, int stack, IValue value) {
            if (stack == 0) Variables[stack][name] = value;
            else {
                if (CheckVariableExists(name, stack)) Variables[stack][name] = value;
                else if (CheckVariableExists(name, 0)) Variables[0][name] = value;
                else Variables[stack][name] = value;
            }
        }

        public void SetVariable(string name, IValue value) {
            SetVariable(name, currentStack, value);
        }

        public IValue GetVariable(string name, int stack) {
            return Variables[stack][name];
        }

        public IValue GetVariable(string name) {
            if (currentStack > 0 && CheckVariableExists(name, currentStack)) return GetVariable(name, currentStack);
            else if (CheckVariableExists(name, 0)) return GetVariable(name, 0);
            else throw new Exception("Cannot find variable " + name);
        }

        public bool CheckVariableExists(string name, int stack) {
            if (name == null) return false;
            return Variables[stack].ContainsKey(name);
        }

        public bool CheckVariableExists(string name) {
            return CheckVariableExists(name, currentStack) || CheckVariableExists(name, 0);
        }
    }
}
