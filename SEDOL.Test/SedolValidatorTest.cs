using SEDOL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SEDOL.Tests
{
    [TestClass]
    public class SedolValidatorTest
    {
        ISedolValidator sedolValidator;
        [TestInitialize]
        public void SetSedolValidatorTest()
        {
            sedolValidator = new SedolValidator();
        }

        [TestMethod]
        public void ShouldReturnErrForNotSevenChar()
        {
            string input = "12";
            var result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.ValidationDetails, Constants.ErrNot7Char);

            input = "1182397189342";
            result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.ValidationDetails, Constants.ErrNot7Char);
        }

        [TestMethod]
        public void ShouldReturnErrInvalidCheckSumNonUser()
        {
            string input = "1234567";
            var result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.ValidationDetails, Constants.ErrInvalidCheckSum);
        }

        [TestMethod]
        public void ShouldReturnTrueForValidSedolNonUser()
        {
            string input = "0709954";
            var result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.IsValidSedol, true);
            Assert.AreEqual(result.ValidationDetails, null);
        }

        [TestMethod]
        public void ShouldReturnInvalidChecksumUserDefined()
        {
            string input = "9123451";
            var result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, true);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.ValidationDetails, Constants.ErrInvalidCheckSum);
        }

        [TestMethod]
        public void ShouldReturnInvalidCharFoundErr()
        {
            string input = "9123_51";
            var result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, false);
            Assert.AreEqual(result.IsValidSedol, false);
            Assert.AreEqual(result.ValidationDetails, Constants.ErrInvalidChar);
        }

        [TestMethod]
        public void ShouldReturnValidSedolUserDefiner()
        {
            string input = "9123458";
            var result = sedolValidator.ValidateSedol(input);
            Assert.AreEqual(result.InputString, input);
            Assert.AreEqual(result.IsUserDefined, true);
            Assert.AreEqual(result.IsValidSedol, true);
            Assert.AreEqual(result.ValidationDetails, null);
        }
    }
}
