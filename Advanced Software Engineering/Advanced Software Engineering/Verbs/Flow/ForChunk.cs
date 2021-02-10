using Advanced_Software_Engineering.Verbs.Value;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Flow {

    /// <summary>
    /// A ForChunk is similar to a <see cref="WhileChunk"/>. It executes a specific number of times.
    /// </summary>
    public class ForChunk : VerbChunk, IVerbChunk, IVerb {
        private readonly IValue conditional;
        private readonly ValueStorage valueStorage;

        /// <summary>
        /// A For Loop object
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="conditional">Preferably <see cref="Value.ValueTypes.IntValue"/>, the number of times the loop should execute.</param>
        public ForChunk(ValueStorage valueStorage, IValue conditional) : base() {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        /// <summary>
        /// A For Loop object
        /// </summary>
        /// <param name="valueStorage">The ValueStorage for increasing and decreasing the stack</param>
        /// <param name="conditional">Preferably <see cref="Value.ValueTypes.IntValue"/>, the number of times the loop should execute.</param>
        /// <param name="oneLineVerb">A verb to execute in a single line</param>
        public ForChunk(ValueStorage valueStorage, IValue conditional, IVerb oneLineVerb) : base(new List<IVerb> { oneLineVerb }) {
            this.conditional = conditional;
            this.valueStorage = valueStorage;
            valueStorage.IncreaseStack();
        }

        /// <summary>
        /// Executes the chunk the number of specified times
        /// </summary>
        public new void ExecuteVerb() {
            int iterations = conditional.ToInt();

            valueStorage.IncreaseStack();
            for (; iterations > 0; iterations--) base.ExecuteVerb();
            valueStorage.DecreaseStack();
        }
    }
}