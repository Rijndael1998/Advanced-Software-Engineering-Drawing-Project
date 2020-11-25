using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Software_Engineering.Verbs.Value.ValueTypes {
    class VariableValue : IValue {

        static Dictionary<string, IValue> variables = new Dictionary<string, IValue>();

        public string GetDescription() {
            throw new NotImplementedException();
        }

        public Type GetOriginalType() {
            throw new NotImplementedException();
        }

        public bool ToBool() {
            throw new NotImplementedException();
        }

        public Color ToColor() {
            throw new NotImplementedException();
        }

        public double ToDouble() {
            throw new NotImplementedException();
        }

        public int ToInt() {
            throw new NotImplementedException();
        }
    }
}
