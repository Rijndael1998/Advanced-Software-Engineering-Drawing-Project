using System;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class UpdateVariable : IVerb {
        protected ValueStorage storage;
        protected string name;
        protected IValue value;

        private void Init(ValueStorage storage, string name, IValue value) {
            this.name = name;
            this.value = value;
            this.storage = storage;
        }

        public UpdateVariable(ValueStorage storage, string name, IValue value) {
            Init(storage, name, value);
        }

        public UpdateVariable(ValueStorage storage, string name, string value) {
            // incoming values look something like this "= 10"
            // or "= 10 + i"
            Init(storage, name, ValueHelper.ConvertToIValue(value, storage));
        }

        public void ExecuteVerb() {
            if (!storage.CheckVariableExists(name)) throw new Exception("Cannot update variable because it is not declared");
            storage.SetVariable(name, value.Clone());
        }

        public string GetDescription() {
            return "Updates " + name + " to " + value;
        }
    }
}