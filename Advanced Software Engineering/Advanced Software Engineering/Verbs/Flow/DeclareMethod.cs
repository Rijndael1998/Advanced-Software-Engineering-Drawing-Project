namespace Advanced_Software_Engineering.Verbs.Flow {

    public class DeclareMethod : IVerb, IVerbChunk {
        private readonly string methodName;
        private readonly Drawer drawer;

        public DeclareMethod(Drawer drawer, string methodName) {
            this.drawer = drawer;
            this.methodName = methodName;
        }

        public void AddVerb(IVerb verb) {
            MethodChunk methodChunk = drawer.Methods[methodName];
            methodChunk.AddVerb(verb);
        }

        public void ExecuteVerb() {
            //Declaration of method happens at parse time
        }

        public string GetDescription() {
            return "Declares a method";
        }
    }
}