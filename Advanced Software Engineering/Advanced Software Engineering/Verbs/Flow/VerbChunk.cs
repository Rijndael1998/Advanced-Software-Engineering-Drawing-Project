using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {

    public class VerbChunk : IVerbChunk, IVerb {
        private readonly List<IVerb> verbs;

        public VerbChunk(List<IVerb> verbs) {
            this.verbs = verbs;
        }

        public VerbChunk() {
            verbs = new List<IVerb> { };
        }

        public void AddVerb(IVerb verb) {
            verbs.Add(verb);
        }

        public void ExecuteVerb() {
            foreach (IVerb verb in verbs) verb.ExecuteVerb();
        }

        public string GetDescription() {
            string s = "VerbChunk Start";
            foreach (IVerb verb in verbs) s += "\n" + verb.GetDescription();
            return s + "\n" + "VerbChunk End";
        }
    }
}