using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.Value {
    class ValueContainer {

        Dictionary<string, IValue> variables = new Dictionary<string, IValue>();

        public ValueContainer() {

        }

        public void SetVariable(string variableName, IValue iValue) {
            if (variables.ContainsKey(variableName)) ;
        }

        public void DeclareVariable(string variableName, IValue iValue) {

        }

        public void DeclareAndSetVariable(string variableName, IValue iValue) {

        }
    }
}
