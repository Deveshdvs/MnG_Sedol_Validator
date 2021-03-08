using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL
{
    interface ISedolValidationHelper : IValidationHelper
    {
        bool CheckUserDefined(string sedol);
        bool ValidateCheckDigit(string sedol);
    }
}
