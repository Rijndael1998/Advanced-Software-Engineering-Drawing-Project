using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Software_Engineering;
using System;
using System.Collections.Generic;

namespace Advanced_Software_Engineering_Tests {
    [TestClass]
    public class SettingsAndHelperFunctionsTester {
        string alphabet = "abcdefghijklmnopqrstuvwxzy";
        char space = " "[0];
        Random rand = new Random();

        [TestMethod]
        public void TestStrip_Random1() {

            for (int test = 0; test < 200; test++) {
                int until = rand.Next(50);
                string correctOutput = "";

                for (int i = 0; i < until; i++) {
                    correctOutput += alphabet[rand.Next(alphabet.Length)];
                }

                string obfuscatedInput = correctOutput;

                until = rand.Next(50);
                for (int i = 0; i < until; i++) {
                    if (rand.Next(1) == 0) obfuscatedInput += space;
                }

                until = rand.Next(50);
                for (int i = 0; i < until; i++) {
                    if (rand.Next(1) == 0) obfuscatedInput = space + obfuscatedInput;
                }

                Assert.AreEqual(correctOutput, SettingsAndHelperFunctions.Strip(obfuscatedInput));

            }
        }

        [TestMethod]
        public void TestStrip_Manual1() {
            string input = "     a simple sentence surrounded by spaces                ";
            string expected = "a simple sentence surrounded by spaces";

            Assert.AreEqual(expected, SettingsAndHelperFunctions.Strip(input));
        }

        [TestMethod]
        public void TestStrip_Manual2() {
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
            for(int i = 0; i < 100000; i++) {
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
            foreach(string s in SettingsAndHelperFunctions.StripStringArray(input)) {
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
    }
}
