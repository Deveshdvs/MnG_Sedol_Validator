using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL
{
    interface ISedolCalculator
    {
        int CalculateCheckDigit(string sedol);
        int CalculateWeightage(string sedol);
    }
}
