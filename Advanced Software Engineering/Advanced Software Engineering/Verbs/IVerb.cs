namespace Advanced_Software_Engineering {

    /// <summary>
    /// IVerb is an interface for executing and getting the descriptions of Verbs. Some Verbs draw lines, some verbs will assign
    /// </summary>
    public interface IVerb {

        /// <summary>
        /// This executes the IVerb to the drawer inside it.
        /// </summary>
        void ExecuteVerb();

        /// <summary>
        /// The description of what the IVerb will do.
        /// </summary>
        /// <returns>A string description of what the IVerb will do</returns>
        string GetDescription();
    }
}