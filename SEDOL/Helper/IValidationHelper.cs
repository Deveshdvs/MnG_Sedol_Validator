using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL
{
    interface IValidationHelper
    {
        Tuple<bool, string> ValidateInputstring(string sedol);
    }
}
