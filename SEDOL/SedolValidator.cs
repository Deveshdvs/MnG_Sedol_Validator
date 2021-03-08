using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL
{
    public class SedolValidator : ISedolValidator
    {
        readonly ISedolValidationHelper validationHelper;
        public SedolValidator()
        {
            validationHelper = new SedolValidationHelper();
        }

        /// <summary>
        /// Validates the sedol according to the set of ruls
        /// </summary>
        /// <param name="input"></param>
        /// <returns> ISedolValidationResult with the assigned respecitve properties</returns>
        public ISedolValidationResult ValidateSedol(string input)
        {
            ISedolValidationResult validationResult;
            bool isUserDefined = false;

            try
            {
                Tuple<bool, string> isValidInput = validationHelper.ValidateInputstring(input);

                if (isValidInput.Item1)
                {
                    isUserDefined = validationHelper.CheckUserDefined(input);
                    bool isValidChkDigit = validationHelper.ValidateCheckDigit(input);
                    if (!isValidChkDigit)
                        isValidInput = new Tuple<bool, string>(false, Constants.ErrInvalidCheckSum);
                    else
                        isValidInput = new Tuple<bool, string>(true, null);
                }
                validationResult = new SedolValidationResult(input, isValidInput.Item1, isUserDefined, isValidInput.Item2);
                return validationResult;
            }
            catch
            {
                //Fallback method - Not included in scope
                return new SedolValidationResult(input, false, isUserDefined, Constants.ErrInvalidChar);
            }
        }
    }
}
