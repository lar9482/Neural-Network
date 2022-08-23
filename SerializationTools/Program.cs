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

using SerializationTools.Activation;
using SerializationTools.Error;
using SerializationTools.Learning_Algorithm;

using SerializationTools.Layers.FeedForward.Input;
using SerializationTools.Layers.FeedForward.Dense;
using SerializationTools.Layers.FeedForward.Output;


using Newtonsoft.Json;

namespace SerializationTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Matrix matrix = new Matrix(10, 1);
            List<Matrix> list = new List<Matrix>() { matrix, new Matrix(20, 1), new Matrix(5, 1)};
            //MatrixObject matrixObject = MatrixObject.SerializeMatrix(matrix);

            string matrixOutput = JsonConvert.SerializeObject(matrix);
            Matrix test = (Matrix) JsonConvert.DeserializeObject<Matrix>(matrixOutput);

            string listOutput = JsonConvert.SerializeObject(list);
            List<Matrix> listTest = (List<Matrix>)JsonConvert.DeserializeObject<List<Matrix>>(listOutput);*/


            /*sigmoid sigmoidFunction = new sigmoid();
            string sigmoidJson = ActivationSerialization.SerializeActivation(sigmoidFunction);
            sigmoid newSigmoidFunction = (sigmoid)ActivationSerialization.DeserializeActivation(sigmoidJson);

            crossEntropy crossEntropyFunction = new crossEntropy();
            string crossEntropyJson = ErrorSerialization.SerializeError(crossEntropyFunction);
            crossEntropy newCrossEntropyFunction = (crossEntropy)ErrorSerialization.DeserializeError(crossEntropyJson);

            GradientDescent d = new GradientDescent();
            string json = LearningAlgorithm_Serialization.Serialize_LearningAlgorithm(d);
            GradientDescent aa = (GradientDescent)LearningAlgorithm_Serialization.Deserialize_LearningAlgorithm(json);*/

            int inputFeatureSize = 784;
            int outputFeatureSize = 10;
            int samplingSize = 100;

            InputLayer inputLayer = new InputLayer(inputFeatureSize, samplingSize);
            inputLayer.contents = new Matrix(inputFeatureSize, samplingSize);
            InputLayerObject inputLayerObject = InputLayerObject.SerializeObject(inputLayer);
            string inputJson = JsonConvert.SerializeObject(inputLayerObject);
            InputLayerObject newInputLayerObject = (InputLayerObject)JsonConvert.DeserializeObject<InputLayerObject>(inputJson);
            InputLayer newInputLayer = InputLayerObject.DeserializeObject(newInputLayerObject);

            DenseLayer denseLayer = new DenseLayer(365, 0.5, inputLayer, new sigmoid(), new GradientDescent());
            denseLayer.feedForward();
            DenseLayerObject denseLayerObject = DenseLayerObject.serializeObject(denseLayer);
            string denseJson = JsonConvert.SerializeObject(denseLayerObject);
            DenseLayerObject newDenseLayerObject = (DenseLayerObject)JsonConvert.DeserializeObject<DenseLayerObject>(denseJson);
            DenseLayer newDenseLayer = DenseLayerObject.deserializeObject(newDenseLayerObject);


            OutputLayer outputLayer = new OutputLayer(new Matrix(outputFeatureSize, samplingSize), 
                                      0.5, denseLayer, new sigmoid(), new crossEntropy(), new GradientDescent());
            outputLayer.feedForward();
            OutputLayerObject outputLayerObject = OutputLayerObject.serializeObject(outputLayer);
            string outputJson = JsonConvert.SerializeObject(outputLayerObject);
            OutputLayerObject newOutputLayerObject = (OutputLayerObject)JsonConvert.DeserializeObject<OutputLayerObject>(outputJson);
            OutputLayer newOutputLayer = OutputLayerObject.deserializeObject(outputLayerObject);
        }
    }
}
