namespace Advanced_Software_Engineering.Verbs.DrawingVerbs.Actions {

    internal class NoOp : IVerb {

        public void ExecuteVerb() {
        }

        public string GetDescription() {
            return "NoOp";
        }
    }
}