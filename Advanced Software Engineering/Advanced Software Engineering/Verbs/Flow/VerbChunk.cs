using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {

    /// <summary>
    /// A simple VerbChunk. Used for storing and executing a bunch of verbs
    /// </summary>
    public class VerbChunk : IVerbChunk, IVerb {
        private readonly List<IVerb> verbs;

        /// <summary>
        /// Create a new VerbChunk with verbs in it.
        /// </summary>
        /// <param name="verbs">Verbs to be added to the verb chunk</param>
        public VerbChunk(List<IVerb> verbs) {
            this.verbs = verbs;
        }

        /// <summary>
        /// Create an empty VerbChunk
        /// </summary>
        public VerbChunk() {
            verbs = new List<IVerb> { };
        }

        /// <summary>
        /// Adds a verb to the verb list
        /// </summary>
        /// <param name="verb"></param>
        public void AddVerb(IVerb verb) {
            verbs.Add(verb);
        }

        /// <summary>
        /// Executes all of the verbs in order
        /// </summary>
        public void ExecuteVerb() {
            foreach (IVerb verb in verbs) verb.ExecuteVerb();
        }

        /// <summary>
        /// Returns all of the verbs stored
        /// </summary>
        /// <returns>the verbs stored</returns>
        public IVerb[] GetVerbs() {
            return verbs.ToArray();
        }

        /// <summary>
        /// Gets a description of every verb
        /// </summary>
        /// <returns>The descriptions of every verb</returns>
        public string GetDescription() {
            string s = "VerbChunk Start";
            foreach (IVerb verb in verbs) s += "\n" + verb.GetDescription();
            return s + "\n" + "VerbChunk End";
        }
    }
}