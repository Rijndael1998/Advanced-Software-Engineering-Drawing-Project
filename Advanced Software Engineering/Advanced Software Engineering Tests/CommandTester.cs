using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Software_Engineering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced_Software_Engineering_Tests {
    [TestClass]
    public class CommandTester {
        Random rand = new Random();

        [TestMethod]
        public void VerbFactoryTester_Automatic1() {
            Dictionary<string, int[]> commandParamaterNumber = new Dictionary<string, int[]>
            {
                {"moveto",  new int[] { 2 } },
                {"drawto",  new int[] { 2 } },
                {"line",    new int[] { 2 } },
                {"lineto",  new int[] { 2 } },
                {"shape",   new int[] { 2, 3 } }
            };

            foreach (string command in commandParamaterNumber.Keys) {
                foreach (int commandParameterNumbers in commandParamaterNumber[command]) {
                    string input = command + " ";
                    List<int> inputParameters = new List<int>();

                    for (int paramater = 0; paramater < commandParameterNumbers; paramater++) {
                        int inputParameter = rand.Next(1000);
                        inputParameters.Add(inputParameter);
                        input += inputParameter + (paramater - 1 != commandParameterNumbers ? ", " : "");
                    }

                    Verb verb = VerbFactory.MakeVerb(null, input);

                    if (command == "moveto") {
                        string verbDesc = verb.GetDescription();
                        string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
                        Assert.AreEqual(correctDesc, verbDesc);
                    } else if (command == "drawto" || command == "lineto" || command == "line") {
                        string verbDesc = verb.GetDescription();
                        string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
                        Assert.AreEqual(correctDesc, verbDesc);
                    } else if (command == "shape") {
                        string verbDesc = verb.GetDescription();
                        string correctDesc;
                        if (commandParameterNumbers == 2)
                            correctDesc = "Draws a " + inputParameters[0] + " sided regular polygon, with rotation of 0 radians, with inner radius of " + (double) inputParameters[1];
                        else
                            correctDesc = "Draws a " + inputParameters[0] + " sided regular polygon, with rotation of " + (double)(Math.PI * inputParameters[2] / 180) + " radians, with inner radius of " + (double) inputParameters[1];
                        Assert.AreEqual(correctDesc, verbDesc);
                    }

                }

            }

        }

    }
}
