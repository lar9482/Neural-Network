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

            if (errorFunction is MSE)
            {
                return "MSE";
            }
            return "";
        }

        public static errorFunction DeserializeError(string errorFunction)
        {
            switch(errorFunction)
            {
                case "crossEntropy":
                    return new crossEntropy();

                case "MSE":
                    return new MSE();

                default:
                    return new MSE();
            }
        }
    }
}
