using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL.Tests
{
    [TestClass]
    public class SedolCalculatorTest
    {
        ISedolCalculator sedolCalculator;
        [TestInitialize]
        public void SetSedolValidationHelper()
        {
            sedolCalculator = new SedolCalculator();
        }

        [TestMethod]
        public void CalculateCheckDigit_ShouldReturnNegative_NotSedol()
        {
            var result = sedolCalculator.CalculateCheckDigit("12");
            Assert.AreEqual(result, -1);

            result = sedolCalculator.CalculateCheckDigit("1304981342");
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void CalculateCheckDigit_ShouldReturnNegative_SpecialChar()
        {
            var result = sedolCalculator.CalculateCheckDigit("9123_51");
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void CalculateCheckDigit_IsSame_Sedol()
        {
            var result = sedolCalculator.CalculateCheckDigit("9123458");
            Assert.AreNotEqual(result, 6);

            result = sedolCalculator.CalculateCheckDigit("9123458");
            Assert.AreEqual(result, 8);
        }


        [TestMethod]
        public void CalculateWeightage_ShouldReturnNegative_SpecialChar()
        {
            var result = sedolCalculator.CalculateWeightage("9123_51");
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void CalculateWeightage_IsSame_Sedol()
        {
            var result = sedolCalculator.CalculateWeightage("9123458");
            Assert.AreEqual(result, 92);

            result = sedolCalculator.CalculateWeightage("9ABCDE1");
            Assert.AreEqual(result, 299);
        }
    }
}
