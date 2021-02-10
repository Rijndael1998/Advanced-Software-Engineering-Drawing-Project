using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {

    /// <summary>
    /// A Chunk that loops over its code
    /// </summary>
    public class WhileChunk : VerbChunk, IVerbChunk, IVerb {
        private readonly IValue conditional;
        private readonly ValueStorage valueStorage;

        /// <summary>
        /// A For Loop object
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="conditional">Preferably <see cref="Value.ValueTypes.BoolValue"/>, weather the loop should continue to execute.</param>
        public WhileChunk(ValueStorage valueStorage, IValue conditional) : base() {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        /// <summary>
        /// Create a new if object
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="conditional">Preferably <see cref="Value.ValueTypes.BoolValue"/>, weather the loop should continue to execute.</param>
        /// <param name="oneLineVerb">A verb to execute in a single line. (Probably a bad idea)</param>
        public WhileChunk(ValueStorage valueStorage, IValue conditional, IVerb oneLineVerb) : base(new List<IVerb> { oneLineVerb }) {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        /// <summary>
        /// Executes every verb in the chunk
        /// </summary>
        public new void ExecuteVerb() {
            valueStorage.IncreaseStack();
            while (conditional.ToBool()) base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }
    }
}