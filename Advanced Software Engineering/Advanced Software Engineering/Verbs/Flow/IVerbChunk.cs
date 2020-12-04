namespace Advanced_Software_Engineering.Verbs.Flow {
    /// <summary>
    /// A Collection of chunks to be executed. They extend IVerb because they should be interchangable. 
    /// </summary>
    public interface IVerbChunk : IVerb {
        /// <summary>
        /// Adds a verb to the verb list
        /// </summary>
        /// <param name="verb">The verb to add</param>
        void AddVerb(IVerb verb);

        /// <summary>
        /// Execute the whole chunk
        /// </summary>
        new void ExecuteVerb();

        /// <summary>
        /// Gets the description of what the chunk will do
        /// </summary>
        /// <returns>A description of the chunk's actions</returns>
        new string GetDescription();
    }
}