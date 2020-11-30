using Advanced_Software_Engineering.Verbs.Value;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class IfChunk : VerbChunk, IVerb {

        IValue conditional;

        public IfChunk(IValue conditional) : base() {
            this.conditional = conditional;
        }

        public void ExecuteVerb() {
            if (conditional.ToBool()) base.ExecuteVerb();
        }

    }
}
