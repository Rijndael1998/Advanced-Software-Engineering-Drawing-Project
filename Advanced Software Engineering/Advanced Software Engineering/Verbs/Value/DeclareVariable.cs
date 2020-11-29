using System;
using System.Collections.Generic;

namespace Advanced_Software_Engineering.Verbs.Value {

    public class DeclareVariable : IVerb {
        private Drawer drawer;
        private IValue value;
        private string name;

        //Common characters that people might try
        private char[] illegalCharacters = "1234567890!?/+- \"'@#~;:><,.`¬|[]{}\\£$%^&*()".ToCharArray();
        private string[] illegalNames = 
            { "int", "double", "bool", "color",
              "move", "moveto", 
              "drawto", "line", "lineto",
              "regularpolygon", "rp",
              "square",
              "quadrilateral",
              "rectangle",
              "circle",
              "triangle",
              "dot",
              "clear",
              "reset", "resetpen",
              "fillon", "filloff",
              "pen",
              "fill",
            };

        /// <summary>
        /// Checks if the name provided is valid
        /// </summary>
        /// <param name="name">The name of the variable</param>
        /// <returns>True if the name is valid, otherwise false</returns>
        private bool CheckName(string name) {
            foreach (char character in illegalCharacters) {
                if (name.Contains(character.ToString())) return false;
            }

            foreach (string illegalName in illegalNames) {
                if (illegalName == name) return false;
            }

            return true;
        }

        public DeclareVariable(Drawer drawer, string type, string assignment) {
            this.drawer = drawer;

            if (drawer.CheckVariableExists(name)) throw new Exception("Declaration failed. " + name + " has been declared before");
            if (!CheckName(name)) throw new Exception("Name not allowed");

            // get variable name
            // assignment looks something like this at this point:
            // i = 20
            // or
            // i = 2 == 5

            // bools have ==
            if (!(type == "bool")) {
                //Seperate the assignment from the variables
                List<string> assignmentList = SettingsAndHelperFunctions.StripStringArray(assignment.Split("="[0]));
                name = assignmentList[0];
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