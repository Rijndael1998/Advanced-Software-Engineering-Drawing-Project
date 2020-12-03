using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class WhileChunk : VerbChunk, IVerbChunk, IVerb {

        IValue conditional;
        ValueStorage valueStorage;

        public WhileChunk(ValueStorage valueStorage, IValue conditional) : base() {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        public new void ExecuteVerb() {
            valueStorage.IncreaseStack();
            while (conditional.ToBool()) base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }

    }
}
