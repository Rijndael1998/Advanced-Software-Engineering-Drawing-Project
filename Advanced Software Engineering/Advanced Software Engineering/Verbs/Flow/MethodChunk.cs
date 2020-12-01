using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class MethodChunk : VerbChunk, IVerb, IValue {

        ValueStorage valueStorage;
        VariableValue[] variableValues;

        public MethodChunk(VariableValue[] variableValues, ValueStorage valueStorage) : base() {
            this.valueStorage = valueStorage;
            this.variableValues = variableValues;
        }

        public new void ExecuteVerb() {
            valueStorage.IncreaseStack();
            base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }

        public IValue Clone() {
            throw new System.NotImplementedException();
        }

        public string GetOriginalType() {
            throw new System.NotImplementedException();
        }

        public bool isInitialised() {
            throw new System.NotImplementedException();
        }

        public bool ToBool() {
            throw new System.NotImplementedException();
        }

        public Color ToColor() {
            throw new System.NotImplementedException();
        }

        public double ToDouble() {
            throw new System.NotImplementedException();
        }

        public int ToInt() {
            throw new System.NotImplementedException();
        }
    }
}
