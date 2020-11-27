using System;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class DeclareVariable : IVerb {
        private Drawer drawer;
        private IValue value;
        private string name;

        public DeclareVariable(Drawer drawer, string type, string assignment) {
            this.drawer = drawer;

            // get variable name
            // assignment looks something like this at this point: 
            // i = 20
            // or
            // i = 2 == 5

            // bools have ==
            if(!(type == "bool")) {
                //Seperate the assignment from the variables
                List<string> assignmentList = SettingsAndHelperFunctions.StripStringArray(assignment.Split("="[0]));
                name = assignmentList[0];
                if (drawer.CheckVariableExists(name)) throw new Exception("Declaration failed. " + name + " has been declared before");
                value = ValueFactory.CreateValue(assignmentList[1], type);
            } else {
                //boolean here
                throw new NotImplementedException("Booleans cannot be parsed yet");
            }

        }

        public void ExecuteVerb() {
            drawer.SetVariable(name, value);
        }

        public string GetDescription() {
            return "Declares the variable " + name;
        }
    }
}