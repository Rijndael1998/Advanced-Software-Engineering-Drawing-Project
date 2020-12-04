using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Flow {

    /// <summary>
    /// The method chunk class
    /// </summary>
    public class MethodChunk : VerbChunk, IVerb, IValue {
        private readonly ValueStorage valueStorage;
        private readonly DeclareVariable[] variables;
        private UpdateVariable[] updateVariables;
        private bool init = false;
        private IValue result;

        /// <summary>
        /// The method chunk
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="variables">The variables to pass into the method</param>
        public MethodChunk(ValueStorage valueStorage, DeclareVariable[] variables) : base() {
            this.valueStorage = valueStorage;
            this.variables = variables;
        }

        /// <summary>
        /// Gets all of the variable names
        /// </summary>
        /// <returns>The names of all the variables</returns>
        public List<string> GetVariableNames() {
            List<string> VariableNames = new List<string>();
            foreach (DeclareVariable variable in variables) VariableNames.Add(variable.GetName());
            return VariableNames;
        }

        /// <summary>
        /// MUST BE CALLED. This method is really important for setting the updated values into the method's stack.
        /// </summary>
        /// <param name="updateVariables">The new values of the method</param>
        public void SetVariableValues(UpdateVariable[] updateVariables) {
            this.updateVariables = updateVariables;
        }

        /// <summary>
        /// This method allows the method chunk to replicate itself before being ran. Essential for recursion.
        /// </summary>
        /// <returns>A method chunk with the exact same values and verbs</returns>
        public MethodChunk DuplicateForExecution() {
            MethodChunk method = new MethodChunk(valueStorage, variables);
            method.SetVariableValues(updateVariables);

            foreach (IVerb verb in base.GetVerbs()) method.AddVerb(verb);

            return method;
        }

        /// <summary>
        /// Executes the method chunk.
        /// </summary>
        public new void ExecuteVerb() {
            init = false;
            result = null;

            valueStorage.IncreaseStack();

            //Declare everything
            foreach (DeclareVariable variable in variables) variable.ExecuteVerb();

            //Set the values of everything
            foreach (UpdateVariable variable in updateVariables) variable.ExecuteVerb();

            //Run code
            base.ExecuteVerb();
            if (valueStorage.CheckVariableExists("ret")) {
                result = valueStorage.GetVariable("ret");
                init = true;
            }
            valueStorage.DecreaseStack();
        }

        /// <summary>
        /// Gets a result from the method. (Experimental)
        /// </summary>
        /// <returns>the result</returns>
        public IValue GetResult() {
            return result;
        }

        /// <summary>
        /// Clones the result of the method (Experimental)
        /// </summary>
        /// <returns></returns>
        public IValue Clone() {
            return GetResult().Clone();
        }

        /// <summary>
        /// Gets the original type of the result of the method (Experimental)
        /// </summary>
        /// <returns></returns>
        public string GetOriginalType() {
            return GetResult().GetOriginalType();
        }

        /// <summary>
        /// Checks if the result is initilised (Experimental)
        /// </summary>
        /// <returns></returns>
        public bool IsInitialised() {
            return init;
        }

        /// <summary>
        /// Converts the result to boolean (Experimental)
        /// </summary>
        /// <returns>boolean representation of the result</returns>
        public bool ToBool() {
            return GetResult().ToBool();
        }

        /// <summary>
        /// Converts the result to color (Experimental)
        /// </summary>
        /// <returns>color representation of the result</returns>
        public Color ToColor() {
            return GetResult().ToColor();
        }

        /// <summary>
        /// Converts the result to double (Experimental)
        /// </summary>
        /// <returns>double representation of the result</returns>
        public double ToDouble() {
            return GetResult().ToDouble();
        }

        /// <summary>
        /// Converts the result to integer (Experimental)
        /// </summary>
        /// <returns>integer representation of the result</returns>
        public int ToInt() {
            return GetResult().ToInt();
        }
    }
}