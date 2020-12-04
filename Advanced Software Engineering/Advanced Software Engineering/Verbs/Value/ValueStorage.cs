using System;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {

    /// <summary>
    /// The storage for all the values
    /// </summary>
    public class ValueStorage {
        private int currentStack;

        /// <summary>
        /// The list is structured something like this:
        /// <code>
        /// {stack, stack, stack stack}
        /// </code>
        /// Where 'stack' is a dictionary of the names and the values of the variables
        /// </summary>
        private List<Dictionary<string, IValue>> Variables = new List<Dictionary<string, IValue>>();

        /// <summary>
        /// Create a new ValueStorage
        /// </summary>
        public ValueStorage() {
            Reset();
        }

        /// <summary>
        /// Reset the ValueStorage
        /// </summary>
        public void Reset() {
            Variables = new List<Dictionary<string, IValue>>();
            Variables.Add(new Dictionary<string, IValue>());
            currentStack = 0;
        }

        /// <summary>
        /// Set the ValueStorage stack
        /// </summary>
        /// <param name="stack">stack number</param>
        private void SetStack(int stack) {
            if (stack < 0) throw new Exception("Stack cannot be less than 0");

            //Decreased Stack
            if (currentStack > stack) {
                Variables.RemoveAt(currentStack);
            }
            //Increased Stack
            else if (currentStack < stack) {
                Variables.Add(new Dictionary<string, IValue>());
            }

            currentStack = stack;
        }

        /// <summary>
        /// Increase the stack
        /// </summary>
        public void IncreaseStack() {
            SetStack(currentStack + 1);
        }

        /// <summary>
        /// Decrease the stack
        /// </summary>
        public void DecreaseStack() {
            if (currentStack > 0) {
                SetStack(currentStack - 1);
            }
        }

        /// <summary>
        /// Set a variable
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <param name="stack">the start stack</param>
        /// <param name="value">the IValue</param>
        private void SetVariable(string name, int stack, IValue value) {
            for (int internalStack = stack; internalStack >= 0; internalStack--) {
                if (value == null || CheckVariableExists(name, internalStack)) {
                    Variables[internalStack][name] = value;
                    return;
                }
            }
            Variables[stack][name] = value;
        }

        /// <summary>
        /// Set a variable
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <param name="value">the IValue</param>
        public void SetVariable(string name, IValue value) {
            SetVariable(name, currentStack, value);
        }

        /// <summary>
        /// Gets the variable at the specified stack
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="stack">stack</param>
        /// <returns>IValue</returns>
        private IValue GetVariable(string name, int stack) {
            return Variables[stack][name];
        }

        /// <summary>
        /// Gets the variable at the first available stack
        /// </summary>
        /// <param name="name">the names of the variable</param>
        /// <returns>IValue</returns>
        public IValue GetVariable(string name) {
            for (int stack = currentStack; stack >= 0; stack--) {
                if (CheckVariableExists(name, stack) && GetVariable(name, stack) != null) return GetVariable(name, stack);
            }
            throw new Exception("Cannot find variable " + name);
        }

        /// <summary>
        /// Check if the variable exists at the stack specified
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="stack">stack</param>
        /// <returns>IValue</returns>
        private bool CheckVariableExists(string name, int stack) {
            if (name == null) return false;
            return Variables[stack].ContainsKey(name);
        }

        /// <summary>
        /// Check if the variable exists in the first available stack
        /// </summary>
        /// <param name="name">variable name</param>
        /// <returns>IValue</returns>
        public bool CheckVariableExists(string name) {
            if (name == null) return false;
            for (int stack = currentStack; stack >= 0; stack--) {
                if (CheckVariableExists(name, stack)) return true;
            }
            return false;
        }
    }
}