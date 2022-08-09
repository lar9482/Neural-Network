using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neural_Network.MatrixLibrary;
using Neural_Network.Activation;
using Neural_Network.Error;


using Neural_Network.Layers.FeedForward.InputLayer;
using Neural_Network.Layers.FeedForward.DenseLayer;

namespace Neural_Network
{
    internal class primitiveNetwork
    {
        public static void Main(String[] args)
        {
            int sampling = 5;
            int features = 10;

            int layerSize1 = 5;
            int layerSize2 = 3;
            int layerSize3 = 1;

            activationFunction a = new sigmoid();
            errorFunction e = new crossEntropy();

            Matrix inputVector = new Matrix(features, sampling);

            InputLayer inputLayer = new InputLayer(features, sampling);

            
            DenseLayer hiddenLayer1 = new DenseLayer(inputLayer, layerSize1, a);
            DenseLayer hiddenLayer2 = new DenseLayer(hiddenLayer1, layerSize2, a);
            DenseLayer hiddenLayer3 = new DenseLayer(hiddenLayer2, layerSize3, a);

            inputLayer.inputDataset(inputVector);
            hiddenLayer1.feedForward();
            hiddenLayer2.feedForward();
            hiddenLayer3.feedForward();

        }
    }
}
