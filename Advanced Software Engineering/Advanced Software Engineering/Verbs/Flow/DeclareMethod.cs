namespace Advanced_Software_Engineering.Verbs.Flow {

    /// <summary>
    /// Declares a method. See <see cref="DrawingVerbs.Actions.NoOp"/> because these classes behave similarly
    /// </summary>
    public class DeclareMethod : IVerb, IVerbChunk {
        private readonly string methodName;
        private readonly Drawer drawer;

        /// <summary>
        /// Creates a new DeclareMethod object
        /// </summary>
        /// <param name="drawer">The drawer is used for getting the method specifically</param>
        /// <param name="methodName">The name of the method</param>
        public DeclareMethod(Drawer drawer, string methodName) {
            this.drawer = drawer;
            this.methodName = methodName;
        }

        /// <summary>
        /// Adds a verb to the verb list. More specifically, the verb list of the MethodChunk.
        /// See <see cref="MethodChunk"/>
        /// </summary>
        /// <param name="verb">The verb to add</param>
        public void AddVerb(IVerb verb) {
            MethodChunk methodChunk = drawer.Methods[methodName];
            methodChunk.AddVerb(verb);
        }

        /// <summary>
        /// This method quite literally does nothing upon execution because the declaration of method happens at parse time
        /// </summary>
        public void ExecuteVerb() { }

        /// <summary>
        /// Gets the description of what the chunk will do
        /// </summary>
        /// <returns>A description of the chunk's actions</returns>
        public string GetDescription() {
            return "Declares a method";
        }
    }
}