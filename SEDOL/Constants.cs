using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDOL
{
    class Constants
    {
        public const string ErrNot7Char = "Input string was not 7-characters long";
        public const string ErrInvalidChar = "SEDOL contains invalid characters";
        public const string ErrInvalidCheckSum = "Checksum digit does not agree with the rest of the input";
    }
}
