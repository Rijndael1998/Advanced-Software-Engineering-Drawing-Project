using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class IfChunk : VerbChunk, IVerbChunk, IVerb {

        IValue conditional;
        ValueStorage valueStorage;

        public IfChunk(ValueStorage valueStorage, IValue conditional) : base() {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        public IfChunk(ValueStorage valueStorage, IValue conditional, IVerb oneLineVerb) : base(new List<IVerb> { oneLineVerb }) {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        public new void ExecuteVerb() {
            valueStorage.IncreaseStack();
            if (conditional.ToBool()) base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }

    }
}
