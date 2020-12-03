using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public interface IVerbChunk : IVerb {
        void AddVerb(IVerb verb);

        void ExecuteVerb();

        string GetDescription();
    }
}
