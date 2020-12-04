using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {

    /// <summary>
    /// Variable value is responsible for setting up values for <see cref="UpdateVariable"/> to then update
    /// </summary>
    public class VariableValue : IValue {
        private readonly ValueStorage storage;
        private readonly string variableName;

        /// <summary>
        /// The new VariableValue
        /// </summary>
        /// <param name="storage">the storage to use</param>
        /// <param name="variableName">variable name</param>
        public VariableValue(ValueStorage storage, string variableName) {
            this.variableName = variableName;
            if (!storage.CheckVariableExists(variableName)) throw new Exception("Tried to access " + variableName + " before it was assigned. ");
            this.storage = storage;
        }

        /// <summary>
        /// Get the variable value
        /// </summary>
        /// <returns><see cref="IValue"/></returns>
        private IValue Get() {
            return storage.GetVariable(variableName);
        }

        /// <summary>
        /// Gets the description of the IValue
        /// </summary>
        /// <returns>description of the IValue</returns>
        public string GetDescription() {
            return Get().GetDescription();
        }

        /// <summary>
        /// Gets the original type of the IValue
        /// </summary>
        /// <returns>original type of the IValue</returns>
        public string GetOriginalType() {
            return Get().GetOriginalType();
        }

        /// <summary>
        /// Get the initialised state of the IValue
        /// </summary>
        /// <returns>initialised state of the IValue</returns>
        public bool isInitialised() {
            return Get().isInitialised();
        }

        /// <summary>
        /// Converts the IValue to a boolean
        /// </summary>
        /// <returns>Boolean value of the IValue</returns>
        public bool ToBool() {
            return Get().ToBool();
        }

        /// <summary>
        /// Converts the IValue to a color
        /// </summary>
        /// <returns>Color value of the IValue</returns>
        public Color ToColor() {
            return Get().ToColor();
        }

        /// <summary>
        /// Converts the IValue to a double
        /// </summary>
        /// <returns>Double value of the IValue</returns>
        public double ToDouble() {
            return Get().ToDouble();
        }

        /// <summary>
        /// Converts the IValue to an integer
        /// </summary>
        /// <returns>Int value of the IValue</returns>
        public int ToInt() {
            return Get().ToInt();
        }

        /// <summary>
        /// Clone the value and return it
        /// </summary>
        /// <returns>Cloned IValue</returns>
        public IValue Clone() {
            return Get().Clone();
        }
    }
}