using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {

    /// <summary>
    /// A simple If Object
    /// </summary>
    public class IfChunk : VerbChunk, IVerbChunk, IVerb {
        private readonly IValue conditional;
        private readonly ValueStorage valueStorage;

        /// <summary>
        /// Create a new if object
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="conditional">Preferably <see cref="Value.ValueTypes.BoolValue"/>, if the chunk should execute.</param>
        public IfChunk(ValueStorage valueStorage, IValue conditional) : base() {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        /// <summary>
        /// Create a new if object
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="conditional">Preferably <see cref="Value.ValueTypes.BoolValue"/>, if the chunk should execute.</param>
        /// <param name="oneLineVerb">A verb to execute in a single line</param>
        public IfChunk(ValueStorage valueStorage, IValue conditional, IVerb oneLineVerb) : base(new List<IVerb> { oneLineVerb }) {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        /// <summary>
        /// Executes the chunk if the conditional is true
        /// </summary>
        public new void ExecuteVerb() {
            valueStorage.IncreaseStack();
            if (conditional.ToBool()) base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }
    }
}