using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.Layers.FeedForward.Input;
using Neural_Network.Layers.FeedForward.Dense;
using Neural_Network.Layers.FeedForward.Output;

using Neural_Network.Activation;

using Neural_Network.LearningAlgorithmBase;

using Neural_Network.MatrixLibrary;

namespace Neural_Network.Network
{
    public class FeedForward_Network
    {
        private InputLayer inputLayer;
        private List<DenseLayer> hiddenLayers;
        private OutputLayer outputLayer;

        private int samplingSize;
        private int featureSize;


        public FeedForward_Network(int featureSize, int samplingSize)
        {
            this.samplingSize = samplingSize;
            this.featureSize = featureSize;

            this.inputLayer = new InputLayer(featureSize, samplingSize);
        }

        public void addDenseLayer(int layerSize, double learningRate, activationFunction activation, LearningAlgorithm algorithm)
        {
            if (hiddenLayers.Count == 0)
            {
                hiddenLayers.Add(new DenseLayer(layerSize, learningRate, inputLayer, activation, algorithm));
            }
            else
            {
                hiddenLayers.Add(new DenseLayer(layerSize, learningRate, hiddenLayers.Last(), activation, algorithm));
            }
        }

        public void train(Matrix input, Matrix output, int epochs)
        {
            if (!inputCheck(input))
            {
                Console.WriteLine("Make sure the input dataset's dimensions matches the feature and sampling size");
                return;
            }
            if (!outputCheck(output))
            {
                Console.WriteLine("Make sure the input dataset's dimensions matches the feature and sampling size");
                return;
            }


            for (int i = 1; i <= epochs; i++)
            {

            }
        }


        private bool inputCheck(Matrix input)
        {
            return (input.rows == featureSize && (input.cols % samplingSize==0));
        }
        private bool outputCheck(Matrix output)
        {
            return (output.cols == samplingSize);
        }
    }
}
