using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Exceptions
{
    public class RpgException : Exception
    {
        public RpgException()
        {
        }

        public RpgException(string message)
        : base(message)
        {
        }

        public RpgException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
