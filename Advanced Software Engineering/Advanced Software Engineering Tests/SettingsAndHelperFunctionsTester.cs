using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Software_Engineering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Software_Engineering_Tests {
    [TestClass]
    public class SettingsAndHelperFunctionsTester {
        string alphabet = "abcdefghijklmnopqrstuvwxzy";
        char space = " "[0];
        Random rand = new Random();

        [TestMethod]
        public void Strip_Random1() {

            for (int test = 0; test < 200; test++) {
                int until = rand.Next(50);
                string correctOutput = "";

                for (int i = 0; i < until; i++) {
                    correctOutput += alphabet[rand.Next(alphabet.Length)];
                }

                string obfuscatedInput = correctOutput;

                obfuscatedInput = randomSpaces() + obfuscatedInput + randomSpaces();

                Assert.AreEqual(correctOutput, SettingsAndHelperFunctions.Strip(obfuscatedInput));

            }
        }

        [TestMethod]
        public void Strip_Manual1() {
            string input = "     a simple sentence surrounded by spaces                ";
            string expected = "a simple sentence surrounded by spaces";

            Assert.AreEqual(expected, SettingsAndHelperFunctions.Strip(input));
        }

        [TestMethod]
        public void Strip_Manual2() {
            string input = "      a    simple    sentence     surrounded    by    spaces                 ";
            string expected = "a    simple    sentence     surrounded    by    spaces";

            Assert.AreEqual(expected, SettingsAndHelperFunctions.Strip(input));
        }

        [TestMethod]
        public void ConvertToInt_Random1() {
            for (int i = 0; i < 100000; i++) {
                int expected = rand.Next(int.MinValue, int.MaxValue);
                string input = expected.ToString();

                Assert.AreEqual(expected, SettingsAndHelperFunctions.ConvertToInt(input));
            }
        }

        [TestMethod]
        public void ConvertToDouble_Random1() {
            for (int i = 0; i < 100000; i++) {
                double expected = rand.NextDouble();
                string input = expected.ToString();

                Assert.AreEqual(expected, SettingsAndHelperFunctions.ConvertToDouble(input));
            }
        }

        [TestMethod]
        public void StripStringArray_Manual1() {
            string[] input = { "    ", " a   ", " test", "t", "asdf ", "" };
            string[] expected = (new List<string> { "a", "test", "t", "asdf" }).ToArray();

            int i = 0;
            foreach (string s in SettingsAndHelperFunctions.StripStringArray(input)) {
                Assert.AreEqual(expected[i++], s);
            }
        }

        [TestMethod]
        public void StripStringArray_Manual2() {
            string[] input = "a    simple sentence     surrounded by    spaces".Split(" "[0]);
            string[] expected = (new List<string> { "a", "simple", "sentence", "surrounded", "by", "spaces" }).ToArray();

            int i = 0;
            foreach (string s in SettingsAndHelperFunctions.StripStringArray(input)) {
                Assert.AreEqual(expected[i++], s);
            }
        }

        [TestMethod]
        public void CommandAndParameterParser_Manual1() {
            Dictionary<string, string[]> commands = SettingsAndHelperFunctions.CommandAndParameterParser("moveto 200, 200");
            Assert.AreEqual("moveto", commands["command"][0]);
            Assert.AreEqual("200", commands["parameters"][0]);
            Assert.AreEqual("200", commands["parameters"][1]);
        }

        [TestMethod]
        public void CommandAndParameterParser_Manual2() {
            Dictionary<string, string[]> commands = SettingsAndHelperFunctions.CommandAndParameterParser("clear");
            Assert.AreEqual("clear", commands["command"][0]);
            Assert.IsFalse(commands.Keys.Contains("parameters"));
        }

        [TestMethod]
        public void CommandAndParameterParser_Manual3() {
            Dictionary<string, string[]> commands = SettingsAndHelperFunctions.CommandAndParameterParser("");
            Assert.IsFalse(commands.Keys.Contains("command"));
            Assert.IsFalse(commands.Keys.Contains("parameters"));
        }

        [TestMethod]
        public void CommandAndParameterParser_Manual4() {
            Dictionary<string, string[]> commands = SettingsAndHelperFunctions.CommandAndParameterParser("    genericCommand    2, 3,4 5");

            Assert.AreEqual("genericCommand", commands["command"][0]);
            Assert.AreEqual("2", commands["parameters"][0]);
            Assert.AreEqual("3", commands["parameters"][1]);
            Assert.AreEqual("4 5", commands["parameters"][2]);
        }

        string randomSpaces() {
            string spaces = " ";
            for (int i = 0; i < 50; i++) spaces += " ";
            return spaces;
        }

        [TestMethod]
        public void CommandAndParameterParser_Random1() {
            
            string[] randomCommands = {"test", "moveto", "lineto", "markiplier", "clear", "shape", "etc" };
            
            for(int test = 0; test < 10000; test++) {
                string command = randomCommands[rand.Next(randomCommands.Length)];
                string input = randomSpaces() + command;

                List<string> parameters = new List<string>();
                for(int parameterI = 0; parameterI < rand.Next(99) + 1; parameterI++) {
                    string parameter = (rand.NextDouble() * rand.Next(-1000, 1000)).ToString();
                    parameters.Add(parameter);
                    input += randomSpaces() + parameter + randomSpaces() + "," + randomSpaces();
                }

                Dictionary<string, string[]> commands = SettingsAndHelperFunctions.CommandAndParameterParser(input);

                Assert.AreEqual(command, commands["command"][0]);

                int i = 0;
                foreach(string expected in parameters) {
                    Assert.AreEqual(expected, commands["parameters"][i++]);
                }

            }

        }
    }
}
