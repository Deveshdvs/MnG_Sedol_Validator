using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDOL;

namespace SEDOLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Sedol test");
            bool keepLooping = true;

            string input;
            while (keepLooping)
            {
                Console.WriteLine("Please enter a SEDOL string to validate");
                input = System.Console.ReadLine();
                if (input.ToUpper() == "EXIT")
                {
                    break;
                }

                ISedolValidationResult result = new SedolValidator().ValidateSedol(input);
                Console.WriteLine(string.Concat(result.InputString, "|", result.IsValidSedol, "|", result.IsUserDefined, "|", result.ValidationDetails));
                Console.WriteLine();
            }
        }
    }
}
