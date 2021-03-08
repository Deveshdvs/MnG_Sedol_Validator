using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL
{
    class SedolValidationResult : ISedolValidationResult
    {
        public SedolValidationResult(string inputString, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            InputString = inputString;
            IsValidSedol = isValidSedol;
            IsUserDefined = isUserDefined;
            ValidationDetails = validationDetails;
        }
        public string InputString { get; }

        public bool IsValidSedol { get; }

        public bool IsUserDefined { get; }

        public string ValidationDetails { get; }
    }
}
