using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neural_Network.MatrixLibrary;
using Neural_Network.Activation;
using Neural_Network.Error;


using Neural_Network.Layers.FeedForward.Input;
using Neural_Network.Layers.FeedForward.Dense;
using Neural_Network.Layers.FeedForward.Output;

using Neural_Network.LearningAlgorithmBase.GradientDescent;

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

            InputLayer inputLayer = new InputLayer(inputVector);


            DenseLayer hiddenLayer1 = new DenseLayer(layerSize1, inputLayer, a, new GradientDescent());
            DenseLayer hiddenLayer2 = new DenseLayer(layerSize2, hiddenLayer1, a, new GradientDescent());
            DenseLayer hiddenLayer3 = new DenseLayer(layerSize3, hiddenLayer2, a, new GradientDescent());

            Matrix truthVector = new Matrix(10, sampling);
            OutputLayer outputLayer = new OutputLayer(truthVector, hiddenLayer3, a, e, new GradientDescent());


            hiddenLayer1.feedForward();
            hiddenLayer2.feedForward();
            hiddenLayer3.feedForward();
            outputLayer.feedForward();

            outputLayer.backPropagate();
            hiddenLayer3.backPropagate();
            hiddenLayer2.backPropagate();
            hiddenLayer1.backPropagate();


            Matrix actualVector = outputLayer.contents;

        }
    }
}
