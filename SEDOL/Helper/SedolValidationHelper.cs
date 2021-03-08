using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("SEDOL.Test")]
namespace SEDOL
{
    internal class SedolValidationHelper : ISedolValidationHelper
    {
        const string validRegex = "^[a-zA-Z0-9]*$";

        /// <summary>
        /// Validates the input sedol, checks for alphanumeric and length
        /// </summary>
        /// <param name="sedol"></param>
        /// <returns>True, false with validation message</returns>
        public Tuple<bool, string> ValidateInputstring(string sedol)
        {
            if (string.IsNullOrEmpty(sedol) || sedol.Length != 7)
                return new Tuple<bool, string>(false, Constants.ErrNot7Char);

            if (!Regex.IsMatch(sedol, validRegex))
                return new Tuple<bool, string>(false, Constants.ErrInvalidChar);

            return new Tuple<bool, string>(true, null);
        }

        /// <summary>
        /// Checks if sedol is user defined
        /// </summary>
        /// <param name="sedol"></param>
        /// <returns>true for user defined sedol</returns>
        public bool CheckUserDefined(string sedol)
        {
            if (!ValidateInputstring(sedol).Item1 || (int)char.GetNumericValue(sedol[0]) != 9)
                return false;
            return true;
        }

        /// <summary>
        /// Checks the check digit of sedol
        /// </summary>
        /// <param name="sedol"></param>
        /// <returns> false for invalid sedol or check digit, true for valid checkdigit</returns>
        public bool ValidateCheckDigit(string sedol)
        {
            if (!ValidateInputstring(sedol).Item1)
                return false;

            ISedolCalculator weightageCalculator = new SedolCalculator();
            int checkDigit = weightageCalculator.CalculateCheckDigit(sedol);
            return checkDigit == char.GetNumericValue(sedol[6]);
        }
    }
}
