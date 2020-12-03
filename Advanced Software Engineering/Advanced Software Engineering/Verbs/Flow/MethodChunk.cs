using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Flow {

    public class MethodChunk : VerbChunk, IVerb, IValue {
        private readonly ValueStorage valueStorage;
        private readonly DeclareVariable[] variables;
        private UpdateVariable[] updateVariables;
        private bool init = false;
        private IValue result;

        public MethodChunk(ValueStorage valueStorage, DeclareVariable[] variables) : base() {
            this.valueStorage = valueStorage;
            this.variables = variables;
        }

        public List<string> GetVariableNames() {
            List<string> VariableNames = new List<string>();
            foreach (DeclareVariable variable in variables) VariableNames.Add(variable.GetName());
            return VariableNames;
        }

        public DeclareVariable[] GetVariables() {
            return variables;
        }

        public void SetVariableValues(UpdateVariable[] updateVariables) {
            this.updateVariables = updateVariables;
        }

        public MethodChunk DuplicateForExecution() {
            MethodChunk method = new MethodChunk(valueStorage, variables);
            method.SetVariableValues(updateVariables);

            foreach (IVerb verb in base.GetVerbs()) method.AddVerb(verb);

            return method;
        }

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

        public IValue GetResult() {
            return result;
        }

        public IValue Clone() {
            return GetResult().Clone();
        }

        public string GetOriginalType() {
            return GetResult().GetOriginalType();
        }

        public bool isInitialised() {
            return init;
        }

        public bool ToBool() {
            return GetResult().ToBool();
        }

        public Color ToColor() {
            return GetResult().ToColor();
        }

        public double ToDouble() {
            return GetResult().ToDouble();
        }

        public int ToInt() {
            return GetResult().ToInt();
        }
    }
}