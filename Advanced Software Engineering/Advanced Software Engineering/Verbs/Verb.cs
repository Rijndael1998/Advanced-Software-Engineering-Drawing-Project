using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering {
    /// <summary>
    /// Verb is an interface for executing and getting the descriptions of Verbs. Some Verbs draw lines, some verbs will assign
    /// </summary>
    public interface Verb {
        /// <summary>
        /// This executes the verb to the drawer inside it.
        /// </summary>
        void ExecuteVerb();
        /// <summary>
        /// The description of what the Verb will do.
        /// </summary>
        /// <returns>A string description of what the Verb will do</returns>
        string GetDescription();
    }
}
