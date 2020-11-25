using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.Value {
    public class InitialiseVariable : IVerb {

        public InitialiseVariable(Drawer drawer, string type, string assgnment) {

        }

        void IVerb.ExecuteVerb() {
            throw new NotImplementedException();
        }

        string IVerb.GetDescription() {
            throw new NotImplementedException();
        }
    }
}
