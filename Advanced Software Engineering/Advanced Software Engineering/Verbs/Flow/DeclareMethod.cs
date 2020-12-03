using Advanced_Software_Engineering.Verbs.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.Flow {
    class DeclareMethod : IVerb, IVerbChunk {

        MethodChunk methodChunk;


        public DeclareMethod(MethodChunk methodChunk) {
            this.methodChunk = methodChunk;
        }

        public void AddVerb(IVerb verb) {
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
