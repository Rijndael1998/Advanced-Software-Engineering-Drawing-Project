using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class ForChunk : VerbChunk, IVerbChunk, IVerb {
        private readonly IValue conditional;
        private readonly ValueStorage valueStorage;

        public ForChunk(ValueStorage valueStorage, IValue conditional) : base() {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        public ForChunk(ValueStorage valueStorage, IValue conditional, IVerb oneLineVerb) : base(new List<IVerb> { oneLineVerb }) {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        public new void ExecuteVerb() {
            int iterations = conditional.ToInt();

            valueStorage.IncreaseStack();
            for (; iterations > 0; iterations--) base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }
    }
}
