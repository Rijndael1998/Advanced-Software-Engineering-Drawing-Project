using Advanced_Software_Engineering.Verbs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Advanced_Software_Engineering_Tests {

    /// <summary>
    /// This class tests <see cref="ValueHelper"/> methods. It uses a combination of manual and random tests.
    /// </summary>
    [TestClass]
    internal class ValueHelperTester {
        private readonly Random rand = new Random();

        /// <summary>
        /// Random <see cref="ValueHelper.ConvertToInt(string)"/> test.
        /// </summary>
        [TestMethod]
        public void ConvertToInt_Random1() {
            for (int i = 0; i < 100000; i++) {
                int expected = rand.Next(int.MinValue, int.MaxValue);
                string input = expected.ToString();

                Assert.AreEqual(expected, ValueHelper.ConvertToInt(input));
            }
        }

        /// <summary>
        /// Random <see cref="ValueHelper.ConvertToDouble(string)"/> test.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_Random1() {
            for (int i = 0; i < 100000; i++) {
                double expected = rand.NextDouble();
                string input = expected.ToString();

                Assert.AreEqual(expected, ValueHelper.ConvertToDouble(input));
            }
        }

        /// <summary>
        /// Random <see cref="ValueHelper.ConvertToDouble(string)"/> test.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_Random2() {
            for (int i = 0; i < 100000; i++) {
                double expected = rand.Next(100, 100) * rand.NextDouble();
                string input = expected.ToString();

                Assert.AreEqual(expected, ValueHelper.ConvertToDouble(input));
            }
        }

        /// <summary>
        /// Random <see cref="ValueHelper.ConvertToDouble(string)"/> test.
        /// </summary>
        [TestMethod]
        public void ConvertToDouble_Random3() {
            for (int i = 0; i < 100000; i++) {
                int expected = rand.Next(100, 100);
                string input = ((double)expected).ToString();

                Assert.AreEqual((double)expected, ValueHelper.ConvertToDouble(input));
            }
        }
    }
}