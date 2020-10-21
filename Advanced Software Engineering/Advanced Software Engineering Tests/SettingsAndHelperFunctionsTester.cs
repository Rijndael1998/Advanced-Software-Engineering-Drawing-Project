using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Software_Engineering;
using System;

namespace Advanced_Software_Engineering_Tests {
    [TestClass]
    public class SettingsAndHelperFunctionsTester {
        string alphabet = "abcdefghijklmnopqrstuvwxzy";
        char space = " "[0];

        [TestMethod]
        public void TestStrip_Random1() {
            Random rand = new Random();

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

    }
}
