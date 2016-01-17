using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Exceptions
{
    public class WrongRequirementException : RpgException
    {
        public WrongRequirementException()
        {
        }

        public WrongRequirementException(string message)
        : base(message)
        {
        }

        public WrongRequirementException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
