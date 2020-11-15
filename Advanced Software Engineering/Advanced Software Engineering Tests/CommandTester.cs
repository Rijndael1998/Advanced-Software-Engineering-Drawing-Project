using Advanced_Software_Engineering;
using Advanced_Software_Engineering.Verbs.DrawingVerbs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advanced_Software_Engineering_Tests {

    /// <summary>
    /// The CommandTester class tests the commands possible, mostly by getting a IVerb and checking it's description..
    /// </summary>
    [TestClass]
    public class CommandTester {
        private readonly Random rand = new Random();

        /// <summary>
        /// Automatically tests:
        /// - moveto
        /// - drawto
        /// - line
        /// - rp
        /// Current todo list:
        /// - square
        /// - rectangle
        /// - circle
        /// - triangle
        /// - dot
        /// - clear
        /// - pen
        /// - fill
        /// </summary>
        [TestMethod]
        public void VerbFactoryTester_Automatic1() {
            Dictionary<string, int[]> commandParamaterNumber = new Dictionary<string, int[]>
            {
                {"moveto",      new int[] { 2 } },
                {"drawto",      new int[] { 2 } },
                {"line",        new int[] { 2 } },
                {"lineto",      new int[] { 2 } },
                {"rp",          new int[] { 2, 3 } },
                //todo:
                {"square",      new int[] { 1, 2, 8 } },
                {"rectangle",   new int[] { 1, 2, 6 } },
                {"circle",      new int[] { 1 } },
                {"triangle",    new int[] { 1, 2 } },
                {"dot",         new int[] { 0 } },
                {"clear",       new int[] { 0 } },
                {"pen",         new int[] { 1, 3 } },
                {"fill",        new int[] { 1, 3 } }
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

                    IVerb IVerb = VerbFactory.MakeVerb(null, input);

                    if (command == "moveto") {
                        string verbDesc = IVerb.GetDescription();
                        string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
                        Assert.AreEqual(correctDesc, verbDesc);
                    } else if (command == "drawto" || command == "lineto" || command == "line") {
                        string verbDesc = IVerb.GetDescription();
                        string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
                        Assert.AreEqual(correctDesc, verbDesc);
                    } else if (command == "shape") {
                        string verbDesc = IVerb.GetDescription();
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

        /// <summary>
        /// tests the "move" command. See <see cref="MoveTo"/>.
        /// </summary>
        [TestMethod]
        public void MoveToTester_Manual1() {
            string input = "move 200, 300";
            string[] inputParameters = { "200", "300" };

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "moveto" command. See <see cref="MoveTo"/>.
        /// </summary>
        [TestMethod]
        public void MoveToTester_Manual2() {
            string input = "moveto 200, 300";
            string[] inputParameters = { "200", "300" };

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Move origin to " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "drawto" command. See <see cref="DrawTo"/>.
        /// </summary>
        [TestMethod]
        public void DrawToTester_Manual1() {
            string input = "drawto 200, 300";
            string[] inputParameters = { "200", "300" };
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "line" command. See <see cref="DrawTo"/>.
        /// </summary>
        [TestMethod]
        public void DrawToTester_Manual2() {
            string input = "line 200, 300";
            string[] inputParameters = { "200", "300" };
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "lineto" command. See <see cref="DrawTo"/>.
        /// </summary>
        [TestMethod]
        public void DrawToTester_Manual3() {
            string input = "lineto 200, 300";
            string[] inputParameters = { "200", "300" };
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Draw line " + inputParameters[0] + ", " + inputParameters[1];
            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "regularpolygon" command. See <see cref="RegularPolygon"/>.
        /// </summary>
        [TestMethod]
        public void RegularPolygonTester_Manual1() {
            string input = "regularpolygon 3, 50";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 0;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "rp" command. See <see cref="RegularPolygon"/>.
        /// </summary>
        [TestMethod]
        public void RegularPolygonTester_Manual2() {
            string input = "rp 3, 50";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 0;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "regularpolygon" command. See <see cref="RegularPolygon"/>.
        /// </summary>
        [TestMethod]
        public void RegularPolygonTester_Manual3() {
            string input = "regularpolygon 3, 50, 25";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 25 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "rp" command. See <see cref="RegularPolygon"/>.
        /// </summary>
        [TestMethod]
        public void RegularPolygonTester_Manual4() {
            string input = "rp 3, 50, 25";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 3;
            double scale = 50;
            double offset = 25 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "square" command. See <see cref="Square"/>.
        /// </summary>
        [TestMethod]
        public void SquareTester_Manual1() {
            string input = "square 500";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 4;
            double scale = 500;
            double offset = 0 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "square" command. See <see cref="Square"/>.
        /// </summary>
        [TestMethod]
        public void SquareTester_Manual2() {
            string input = "square 500, 45";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 4;
            double scale = 500;
            double offset = 45 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "quadrilateral" command using <see cref="DrawLines"/>. See <see cref="Quadrilateral"/>.
        /// </summary>
        [TestMethod]
        public void QuadrilateralTester_Manual1() {
            string input = "quadrilateral 1, 2,  3, 4,  5, 6,  7, 8";
            Point[] points = {
                new Point(1, 2),
                new Point(3, 4),
                new Point(5, 6),
                new Point(7, 8)
            };

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();
            string correctDesc = new DrawLines(null, points).GetDescription();

            Assert.AreEqual(verbDesc, correctDesc);
        }

        /// <summary>
        /// Tests the "circle" command. See <see cref="Circle"/>.
        /// </summary>
        [TestMethod]
        public void CircleTester_Manual1() {
            string input = "circle 100";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            string correctDesc = "Draws a circle radius " + 100d.ToString() + ", with origin of the pen";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "triangle" command. See <see cref="Triangle"/>.
        /// </summary>
        [TestMethod]
        public void TriangleTester_Manual1() {
            string input = "triangle 500";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 3;
            double scale = 500;
            double offset = 0 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "triangle" command. See <see cref="Triangle"/>.
        /// </summary>
        [TestMethod]
        public void TriangleTester_Manual2() {
            string input = "triangle 500, 45";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);

            string verbDesc = IVerb.GetDescription();

            int sides = 3;
            double scale = 500;
            double offset = 45 * Math.PI / 180;
            string correctDesc = "Draws a " + sides + " sided regular polygon, with rotation of " + offset + " radians, with inner radius of " + scale;

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// test the "dot" command. See <see cref="Dot"/>.
        /// </summary>
        [TestMethod]
        public void DotTester_Manual1() {
            string input = "dot";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Places a dot where the pen currently is";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// tests the "clear" command. See <see cref="Circle"/>.
        /// </summary>
        [TestMethod]
        public void ClearTester_Manual1() {
            string input = "clear";
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Clears the canvas";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the "reset" command. See <see cref="ResetPen"/>
        /// </summary>
        [TestMethod]
        public void ResetPenTester_Manual1() {
            string input = "reset";
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Moves pen to the start (0, 0)";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the "resetpen" command. See <see cref="ResetPen"/>.
        /// </summary>
        [TestMethod]
        public void ResetPenTester_Manual2() {
            string input = "resetpen";
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Moves pen to the start (0, 0)";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the command "pen". See <see cref="PenColor"/>
        /// </summary>
        [TestMethod]
        public void PenTester_Manual1() {
            string input = "pen red";
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Set pen color to: Color [Red]";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the command "fill". See <see cref="FillColor"/>.
        /// </summary>
        [TestMethod]
        public void FillTester_Manual1() {
            string input = "fill pink";
            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Set fill color to: Color [Pink]";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the "if" command. It hasn't been implemented yet.
        /// </summary>
        [TestMethod]
        public void IfTester_Manual1() {
            string input = "if i == 10";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Tests if variable 'i' is equal to 10";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the "def" command. It hasn't been implemented yet.
        /// </summary>
        [TestMethod]
        public void MethodTester_Manual1() {
            string input = "def duck, int i";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Create a new method called 'duck' with input 'int i'. The method: ";

            Assert.AreEqual(correctDesc, verbDesc);
        }

        /// <summary>
        /// Tests the "int" declaration and assignment. It hasn't been implemented yet.
        /// </summary>
        [TestMethod]
        public void ValueTester_Manual1() {
            string input = "int i = 10";

            IVerb IVerb = VerbFactory.MakeVerb(null, input);
            string verbDesc = IVerb.GetDescription();
            string correctDesc = "Declares and sets integer 'i' to '10'";

            Assert.AreEqual(correctDesc, verbDesc);
        }
    }
}