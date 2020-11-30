using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class IfChunk : VerbChunk, IVerb {

        IValue conditional;

        public IfChunk(IValue conditional) : base() {
            this.conditional = conditional;
        }

        public IfChunk(IValue conditional, IVerb oneLineVerb) : base(new List<IVerb> { oneLineVerb }) {
            this.conditional = conditional;
        }

        public new void ExecuteVerb() {
            if (conditional.ToBool()) base.ExecuteVerb();
        }

    }
}
