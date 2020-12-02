using Advanced_Software_Engineering.Verbs.Value;
using Advanced_Software_Engineering.Verbs.Value.ValueTypes;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class MethodChunk : VerbChunk, IVerb, IValue {

        ValueStorage valueStorage;
        bool init = false;

        public MethodChunk(ValueStorage valueStorage) : base() {
            this.valueStorage = valueStorage;
        }

        public new void ExecuteVerb() {
            valueStorage.IncreaseStack();
            base.ExecuteVerb();
            valueStorage.DecreaseStack();
            init = true;
        }

        public IValue GetResult() {
            return valueStorage.GetVariable("res");
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
