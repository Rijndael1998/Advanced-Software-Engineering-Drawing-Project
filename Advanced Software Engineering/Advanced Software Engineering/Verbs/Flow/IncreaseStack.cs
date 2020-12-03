using Advanced_Software_Engineering.Verbs.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.Flow {
    public class IncreaseStack : IVerb {

        ValueStorage valueStorage;

        public IncreaseStack(ValueStorage valueStorage) {
            valueStorage.IncreaseStack();
            this.valueStorage = valueStorage;
        }

        public void ExecuteVerb() {
            valueStorage.IncreaseStack();
        }

        public string GetDescription() {
            return "Increase the stack";
        }
    }
}
