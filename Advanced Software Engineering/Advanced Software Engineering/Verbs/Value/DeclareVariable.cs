using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class DeclareVariable : IVerb {
        private Drawer drawer;
        private IValue value;
        private string name;

        public DeclareVariable(Drawer drawer, string type, string assgnment) {
            this.drawer = drawer;

            value = ValueFactory.CreateValue(type, assgnment);
        }

        void IVerb.ExecuteVerb() {
        }

        string IVerb.GetDescription() {
            throw new NotImplementedException();
        }
    }
}