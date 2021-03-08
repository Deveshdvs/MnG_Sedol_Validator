using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEDOL.Tests
{
    [TestClass]
    public class SedolValidationHelperTest
    {
        ISedolValidationHelper sedolValidationHelper;
        [TestInitialize]
        public void SetSedolValidationHelper()
        {
            sedolValidationHelper = new SedolValidationHelper();
        }

        [TestMethod]
        public void ValidateInputstring_ShouldReturnErr_NotSevenChar()
        {
            var result = sedolValidationHelper.ValidateInputstring("12");
            Assert.AreEqual(result.Item2, Constants.ErrNot7Char);
            Assert.AreEqual(result.Item1, false);

            result = sedolValidationHelper.ValidateInputstring("1304981342");
            Assert.AreEqual(result.Item2, Constants.ErrNot7Char);
            Assert.AreEqual(result.Item1, false);
        }

        [TestMethod]
        public void ValidateInputstring_ShouldReturnErr_SpecialChar()
        {
            var result = sedolValidationHelper.ValidateInputstring("9123_51");
            Assert.AreEqual(result.Item2, Constants.ErrInvalidChar);
            Assert.AreEqual(result.Item1, false);

            result = sedolValidationHelper.ValidateInputstring("VA.CDE8");
            Assert.AreEqual(result.Item2, Constants.ErrInvalidChar);
            Assert.AreEqual(result.Item1, false);
        }

        [TestMethod]
        public void ValidateInputstring_ShouldReturnNull_SEDOL()
        {
            var result = sedolValidationHelper.ValidateInputstring("0709954");
            Assert.AreEqual(result.Item2, null);
            Assert.AreEqual(result.Item1, true);
        }

        [TestMethod]
        public void CheckUserDefined_ShouldReturnErr_NonSedol()
        {
            var result = sedolValidationHelper.CheckUserDefined("12");
            Assert.AreEqual(result, false);

            result = sedolValidationHelper.CheckUserDefined("");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CheckUserDefined_ShouldReturnTrue_SEDOL()
        {
            var result = sedolValidationHelper.CheckUserDefined("9123458");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CheckUserDefined_ShouldReturnFalse_SEDOL()
        {
            var result = sedolValidationHelper.CheckUserDefined("0709954");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ValidateCheckDigit_ShouldReturnFalse_NonSedol()
        {
            var result = sedolValidationHelper.ValidateCheckDigit("12");
            Assert.AreEqual(result, false);

            result = sedolValidationHelper.ValidateCheckDigit(null);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ValidateCheckDigit_ShouldReturnTrue_SEDOL()
        {
            var result = sedolValidationHelper.ValidateCheckDigit("9123458");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void ValidateCheckDigit_ShouldReturnFalse_SEDOL()
        {
            var result = sedolValidationHelper.ValidateCheckDigit("9123451");
            Assert.AreEqual(result, false);
        }
    }

}
