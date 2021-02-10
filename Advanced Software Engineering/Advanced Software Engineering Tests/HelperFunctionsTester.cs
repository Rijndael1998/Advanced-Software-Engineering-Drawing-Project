using Advanced_Software_Engineering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Software_Engineering_Tests {

    /// <summary>
    /// This class tests <see cref="HelperFunctions"/> methods. It uses a combination of manual and random tests.
    /// </summary>
    [TestClass]
    public class HelperFunctionsTester {
        private readonly string alphabet = "abcdefghijklmnopqrstuvwxzy";
        private readonly Random rand = new Random();

        /// <summary>
        /// Random strip spaces test
        /// </summary>
        [TestMethod]
        public void Strip_Random1() {
            for (int test = 0; test < 200; test++) {
                int until = rand.Next(50);
                string correctOutput = "";

                for (int i = 0; i < until; i++) {
                    correctOutput += alphabet[rand.Next(alphabet.Length)];
                }

                string obfuscatedInput = correctOutput;

                obfuscatedInput = RandomSpaces() + obfuscatedInput + RandomSpaces();

                Assert.AreEqual(correctOutput, HelperFunctions.Strip(obfuscatedInput));
            }
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.Strip(string)"/> test
        /// </summary>
        [TestMethod]
        public void Strip_Manual1() {
            string input = "     a simple sentence surrounded by spaces                ";
            string expected = "a simple sentence surrounded by spaces";

            Assert.AreEqual(expected, HelperFunctions.Strip(input));
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.Strip(string)"/> test
        /// </summary>
        [TestMethod]
        public void Strip_Manual2() {
            string input = "      a    simple    sentence     surrounded    by    spaces                 ";
            string expected = "a    simple    sentence     surrounded    by    spaces";

            Assert.AreEqual(expected, HelperFunctions.Strip(input));
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.StripStringArray(string[])"/> test.
        /// </summary>
        [TestMethod]
        public void StripStringArray_Manual1() {
            string[] input = { "    ", " a   ", " test", "t", "asdf ", "" };
            string[] expected = (new List<string> { "a", "test", "t", "asdf" }).ToArray();

            int i = 0;
            foreach (string s in HelperFunctions.StripStringArray(input)) {
                Assert.AreEqual(expected[i++], s);
            }
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.StripStringArray(string[])"/> test.
        /// </summary>
        [TestMethod]
        public void StripStringArray_Manual2() {
            string[] input = "a    simple sentence     surrounded by    spaces".Split(" "[0]);
            string[] expected = (new List<string> { "a", "simple", "sentence", "surrounded", "by", "spaces" }).ToArray();

            int i = 0;
            foreach (string s in HelperFunctions.StripStringArray(input)) {
                Assert.AreEqual(expected[i++], s);
            }
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.CommandAndParameterParser(string)"/> test.
        /// </summary>
        [TestMethod]
        public void CommandAndParameterParser_Manual1() {
            CommandAndParameterParserResult commands = HelperFunctions.CommandAndParameterParser("moveto 200, 200");
            Assert.AreEqual("moveto", commands.GetCommand());
            Assert.AreEqual("200", commands.GetParameters()[0]);
            Assert.AreEqual("200", commands.GetParameters()[1]);
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.CommandAndParameterParser(string)"/> test.
        /// </summary>
        [TestMethod]
        public void CommandAndParameterParser_Manual2() {
            CommandAndParameterParserResult commands = HelperFunctions.CommandAndParameterParser("clear");
            Assert.AreEqual("clear", commands.GetCommand());
            Assert.IsTrue(commands.GetParameters() == null);
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.CommandAndParameterParser(string)"/> test.
        /// </summary>
        [TestMethod]
        public void CommandAndParameterParser_Manual3() {
            CommandAndParameterParserResult commands = HelperFunctions.CommandAndParameterParser("");
            Assert.IsTrue(commands == null);
        }

        /// <summary>
        /// Manual <see cref="HelperFunctions.CommandAndParameterParser(string)"/> test.
        /// </summary>
        [TestMethod]
        public void CommandAndParameterParser_Manual4() {
            CommandAndParameterParserResult commands = HelperFunctions.CommandAndParameterParser("    genericCommand    2, 3,4 5");

            Assert.AreEqual("genericCommand", commands.GetCommand());

            string[] parameters = commands.GetParameters();

            Assert.AreEqual("2", parameters[0]);
            Assert.AreEqual("3", parameters[1]);
            Assert.AreEqual("4 5", parameters[2]);
        }

        private string RandomSpaces() {
            string spaces = " ";
            for (int i = 0; i < 50; i++) spaces += " ";
            return spaces;
        }

        /// <summary>
        /// Random <see cref="HelperFunctions.CommandAndParameterParser(string)"/> test.
        /// </summary>
        [TestMethod]
        public void CommandAndParameterParser_Random1() {
            string[] randomCommands = { "test", "moveto", "lineto", "markiplier", "clear", "shape", "etc" };

            for (int test = 0; test < 10000; test++) {
                string command = randomCommands[rand.Next(randomCommands.Length)];
                string input = RandomSpaces() + command;

                List<string> parameters = new List<string>();
                for (int parameterI = 0; parameterI < rand.Next(99) + 1; parameterI++) {
                    string parameter = (rand.NextDouble() * rand.Next(-1000, 1000)).ToString();
                    parameters.Add(parameter);
                    input += RandomSpaces() + parameter + RandomSpaces() + "," + RandomSpaces();
                }

                CommandAndParameterParserResult commands = HelperFunctions.CommandAndParameterParser(input);

                Assert.AreEqual(command, commands.GetCommand());

                int i = 0;
                foreach (string expected in parameters) {
                    Assert.AreEqual(expected, commands.GetParameters()[i++]);
                }
            }
        }
    }
}