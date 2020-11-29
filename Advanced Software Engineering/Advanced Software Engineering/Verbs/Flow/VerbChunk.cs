namespace Advanced_Software_Engineering.Verbs.Flow {

    public class VerbChunk : IVerb {
        private readonly IVerb[] verbs;

        public VerbChunk(IVerb[] verbs) {
            this.verbs = verbs;
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