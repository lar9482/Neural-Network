using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Layers.FeedForward.Input;
using Neural_Network.Layers.FeedForward.Dense;
using Neural_Network.Layers.FeedForward.Output;
using Neural_Network.Activation;
using Neural_Network.Error;
using Neural_Network.LearningAlgorithmBase;
using Neural_Network.LearningAlgorithmBase.GradientDescent;

using SerializationTools.Layers;
using SerializationTools.Activation;


using Newtonsoft.Json;

namespace SerializationTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(10, 1);
            List<Matrix> list = new List<Matrix>() { matrix, new Matrix(20, 1), new Matrix(5, 1)};
            //MatrixObject matrixObject = MatrixObject.SerializeMatrix(matrix);

            string matrixOutput = JsonConvert.SerializeObject(matrix);
            Matrix test = (Matrix) JsonConvert.DeserializeObject<Matrix>(matrixOutput);

            string listOutput = JsonConvert.SerializeObject(list);
            List<Matrix> listTest = (List<Matrix>)JsonConvert.DeserializeObject<List<Matrix>>(listOutput);


            sigmoid sigmoidFunction = new sigmoid();
            string sigmoidJson = ActivationSerialization.SerializeActivation(sigmoidFunction);
            sigmoid newSigmoidFunction = (sigmoid)ActivationSerialization.DeserializeActivation(sigmoidJson);
        }
    }
}
