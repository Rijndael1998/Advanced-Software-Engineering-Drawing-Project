using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    /// <summary>
    /// Used for updating the variables
    /// </summary>
    public class UpdateVariable : IVerb {
        private ValueStorage storage;
        private string name;
        private IValue value;

        /// <summary>
        /// Initilise the object
        /// </summary>
        /// <param name="storage">The storage object</param>
        /// <param name="name">The name of the variable</param>
        /// <param name="value">The value of the variable</param>
        private void Init(ValueStorage storage, string name, IValue value) {
            this.name = name;
            this.value = value;
            this.storage = storage;
        }

        /// <summary>
        /// Create a new UpdateVariable object
        /// </summary>
        /// <param name="storage">The storage object</param>
        /// <param name="name">The name of the variable</param>
        /// <param name="value">The value of the variable</param>
        public UpdateVariable(ValueStorage storage, string name, IValue value) {
            Init(storage, name, value);
        }

        /// <summary>
        /// Create a new UpdateVariable object
        /// </summary>
        /// <param name="storage">The storage object</param>
        /// <param name="name">The name of the variable</param>
        /// <param name="value">The expression of the value</param>
        public UpdateVariable(ValueStorage storage, string name, string value) {
            // incoming values look something like this "= 10"
            // or "= 10 + i"
            Init(storage, name, ValueHelper.ConvertToIValue(value, storage));
        }

        /// <summary>
        /// Executes the verb and updates the variable
        /// </summary>
        public void ExecuteVerb() {
            if (!storage.CheckVariableExists(name)) throw new Exception("Cannot update variable because it is not declared");
            storage.SetVariable(name, value.Clone());
        }

        /// <summary>
        /// Gets the description of the update
        /// </summary>
        /// <returns>A string representation of the description of the update</returns>
        public string GetDescription() {
            return "Updates " + name + " to " + value;
        }
    }
}