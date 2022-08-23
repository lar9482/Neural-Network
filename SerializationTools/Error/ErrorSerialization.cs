using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.Error;
namespace SerializationTools.Error
{
    internal class ErrorSerialization
    {
        public static string SerializeError(errorFunction errorFunction)
        {
            if (errorFunction is crossEntropy)
            {
                return "crossEntropy";
            }
            return "";
        }
    }
}
