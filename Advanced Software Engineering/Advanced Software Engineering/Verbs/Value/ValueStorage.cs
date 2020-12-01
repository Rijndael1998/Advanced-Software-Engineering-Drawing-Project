using System;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {
    public class ValueStorage {

        protected int currentStack;
        protected Dictionary<int, Dictionary<string, IValue>> Variables = new Dictionary<int, Dictionary<string, IValue>>();
        protected List<IValue> VariableList = new List<IValue>();

        public ValueStorage() {
            Reset();
        }

        public void Reset() {
            //for every ivalue
            Variables = new Dictionary<int, Dictionary<string, IValue>>();
            //for (int index = 0; index < VariableList.Count; index++) VariableList[index] = null;
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
            currentStack--;
            SetStack(currentStack);
        }

        public void SetVariable(string name, int stack, IValue value) {
            if (stack == 0) Variables[stack][name] = value;
            else {
                if (CheckVariableExists(name, stack)) Variables[stack][name] = value;
                else if (CheckVariableExists(name, 0)) Variables[0][name] = value;
                else// if(value == null) {
                    Variables[stack][name] = value;
                    //VariableList.Add(Variables[stack][name]);
                //} else {
                //    throw new Exception("Tried setting a variable that was not declared");
                //}
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
