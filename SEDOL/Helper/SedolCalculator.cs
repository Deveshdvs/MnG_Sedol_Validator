using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SEDOLTest")]
namespace SEDOL
{
    internal class SedolCalculator : ISedolCalculator
    {
        private static readonly int[] sedolWeights = { 1, 3, 1, 7, 3, 9 };

        /// <summary>
        /// Calculate checkdigit for a sedol
        /// </summary>
        /// <param name="sedol"></param>
        /// <returns>-1 for invaild sedol and checkdigit int for valid sedol</returns>
        public int CalculateCheckDigit(string sedol)
        {
            int weightage = CalculateWeightage(sedol);
            if (weightage >= 0)
            {
                return (10 - (weightage % 10)) % 10;
            }
            else
                return -1;
        }

        /// <summary>
        /// Calculates the weightage of sedol
        /// </summary>
        /// <param name="sedol"></param>
        /// <returns>int -1 for invalid sedol and weightage for vaild sedol</returns>
        public int CalculateWeightage(string sedol)
        {
            int sum = 0;

            if (string.IsNullOrEmpty(sedol) || sedol.Length != 7)
                return -1;

            for (int i = 0; i < 6; i++)
            {
                if (Char.IsDigit(sedol[i]))
                    sum += (int)char.GetNumericValue(sedol[i]) * sedolWeights[i];

                else if (Char.IsLetter(sedol[i]))
                    sum += (((int)Char.ToUpper(sedol[i]) - 55) * sedolWeights[i]);
                else
                    return -1;

            }
            return sum;
        }
    }
}
