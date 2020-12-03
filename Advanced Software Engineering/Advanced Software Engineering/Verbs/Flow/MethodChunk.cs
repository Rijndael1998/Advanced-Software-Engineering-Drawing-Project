using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class MethodChunk : VerbChunk, IVerb, IValue {

        ValueStorage valueStorage;
        DeclareVariable[] variables;
        bool init = false;
        IValue result;

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

        public new void ExecuteVerb() {
            init = false;
            result = null;
            // The stack increased artificially
            //valueStorage.IncreaseStack();

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
