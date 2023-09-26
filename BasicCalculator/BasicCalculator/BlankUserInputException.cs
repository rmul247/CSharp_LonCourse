using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    [Serializable]
    public class BlankUserInputException : Exception
    {
        public BlankUserInputException()
        {

        }
        public BlankUserInputException(string message) : base(message)
        {

        }
        public BlankUserInputException(string message, Exception innerException) : base(message, innerException)
        {

        }
     
        protected BlankUserInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
