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
                {"moveto",      new int[] { 2 } },
                {"drawto",      new int[] { 2 } },
                {"line",        new int[] { 2 } },
                {"lineto",      new int[] { 2 } },
                {"shape",       new int[] { 2, 3 } },

                {"square",      new int[] { 1, 2 } },
                {"rectangle",   new int[] { 2, 3 } },
                {"circle",      new int[] { 1 } },
                {"triangle",    new int[] { 1, 2 } },
                {"dot",         new int[] { 0 } },
                {"clear",       new int[] { 0 } },
                {"pen",         new int[] {1, 3 } },
                {"fill",         new int[] {1, 3 } }
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
                            correctDesc = "Draws a " + inputParameters[0] + " sided regular polygon, with rotation of 0 radians, with inner radius of " + (double)inputParameters[1];
                        else
                            correctDesc = "Draws a " + inputParameters[0] + " sided regular polygon, with rotation of " + (double)(Math.PI * inputParameters[2] / 180) + " radians, with inner radius of " + (double)inputParameters[1];
                        Assert.AreEqual(correctDesc, verbDesc);
                    }

                }

            }

        }

        [TestMethod]
        public void MoveToTester_Manual1() {
            string input = "move 200, 300";
            string[] inputParameters = { "200", "300" };

            Verb verb = VerbFactory.MakeVerb(null, input);

            string verbDesc = verb.GetDescription();
            string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void MoveToTester_Manual2() {
            string input = "moveto 200, 300";
            string[] inputParameters = { "200", "300" };

            Verb verb = VerbFactory.MakeVerb(null, input);

            string verbDesc = verb.GetDescription();
            string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void DrawToTester_Manual1() {
            string input = "drawto 200, 300";
            string[] inputParameters = { "200", "300" };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void DrawToTester_Manual2() {
            string input = "line 200, 300";
            string[] inputParameters = { "200", "300" };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void DrawToTester_Manual3() {
            string input = "lineto 200, 300";
            string[] inputParameters = { "200", "300" };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void RegularPolygonTester_Manual1() {
            string input = "regularpolygon 3, 50";

            Verb verb = VerbFactory.MakeVerb(null, input);

            string verbDesc = verb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 0;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void RegularPolygonTester_Manual2() {
            string input = "rp 3, 50";

            Verb verb = VerbFactory.MakeVerb(null, input);

            string verbDesc = verb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 0;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void RegularPolygonTester_Manual3() {
            string input = "regularpolygon 3, 50, 25";

            Verb verb = VerbFactory.MakeVerb(null, input);

            string verbDesc = verb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 25 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void RegularPolygonTester_Manual4() {
            string input = "rp 3, 50, 25";

            Verb verb = VerbFactory.MakeVerb(null, input);

            string verbDesc = verb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 25 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        [TestMethod]
        public void DotTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = null; //undecided
        }

        [TestMethod]
        public void ClearTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = null; //undecided
        }

        [TestMethod]
        public void PenTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = null; //undecided
        }

        [TestMethod]
        public void FillTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = null; //undecided
        }

        [TestMethod]
        public void IfTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = null; //undecided
        }

        [TestMethod]
        public void MethodTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
        }

        [TestMethod]
        public void ValueTester_Manual1() {
            string input = "";
            string[] inputParameters = { };
            Verb verb = VerbFactory.MakeVerb(null, input);
            string verbDesc = verb.GetDescription();
            string correctDesc = null; //undecided
        }

    }
}
