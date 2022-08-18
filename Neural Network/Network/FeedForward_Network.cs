using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.Layers.FeedForward.Input;
using Neural_Network.Layers.FeedForward.Dense;
using Neural_Network.Layers.FeedForward.Output;

using Neural_Network.Activation;
using Neural_Network.Error;

using Neural_Network.LearningAlgorithmBase;

using Neural_Network.MatrixLibrary;
using Neural_Network.MatrixLibrary.Utilities;

namespace Neural_Network.Network
{
    public class FeedForward_Network
    {
        private InputLayer inputLayer;
        private List<DenseLayer> hiddenLayers;
        private OutputLayer outputLayer;

        private int samplingSize;
        private int inputFeatureSize;
        private int outputFeatureSize;


        public FeedForward_Network(int inputFeatureSize, int outputFeatureSize, int samplingSize)
        {
            this.inputFeatureSize = inputFeatureSize;
            this.outputFeatureSize = outputFeatureSize;
            this.samplingSize = samplingSize;

            this.inputLayer = new InputLayer(inputFeatureSize, samplingSize);
        }

        public void addDenseLayer(int layerSize, double learningRate, activationFunction activation, LearningAlgorithm algorithm)
        {
            if (hiddenLayers == null)
            {
                hiddenLayers = new List<DenseLayer>();
                hiddenLayers.Add(new DenseLayer(layerSize, learningRate, inputLayer, activation, algorithm));
            }
            else
            {
                hiddenLayers.Add(new DenseLayer(layerSize, learningRate, hiddenLayers.Last(), activation, algorithm));
            }
        }

        public void compile(double learningRate, activationFunction activation, errorFunction error, LearningAlgorithm algorithm)
        {
            this.outputLayer = new OutputLayer(outputFeatureSize, learningRate, hiddenLayers.Last(), activation, error, algorithm);
        }

        public void train(Matrix input, Matrix output, int epochs)
        {
            trainParameterCheck(input, output);

            for (int i = 1; i <= epochs; i++)
            {
                List<int> unusedIndices = Enumerable.Range(0, input.cols).ToList();
                Random rand = new Random();
                while (unusedIndices.Count > 0)
                {
                    List<int> usedIndices = unusedIndices.OrderBy(x => rand.Next()).Take(samplingSize).ToList();
                    unusedIndices = unusedIndices.Except(usedIndices).ToList();

                    Matrix batchedInput = Matrix_Utilities.getMatrixColumns(input, usedIndices);
                    Matrix batchedOutput = Matrix_Utilities.getMatrixColumns(output, usedIndices);

                    inputLayer.contents = batchedInput;
                    outputLayer.truthMatrix = batchedOutput;

                    for (int j = 0; j < hiddenLayers.Count; i++)
                    {
                        hiddenLayers[j].feedForward();
                    }

                    outputLayer.feedForward();
                    outputLayer.backPropagate();

                    for (int j = hiddenLayers.Count-1; j >=0; j--)
                    {
                        hiddenLayers[j].backPropagate();
                    }

                    outputLayer.updateWeights();
                    outputLayer.updateBias();

                    for (int j = hiddenLayers.Count - 1; j >= 0; j--)
                    {
                        hiddenLayers[j].updateWeights();
                        hiddenLayers[j].updateBias();
                    }
                }
            }
        }

        public Matrix predict(Matrix input)
        {
            predictParameterCheck(input);

            return input;
        }

        private void trainParameterCheck(Matrix input, Matrix output)
        {
            if (!inputCheck(input))
            {
                throw new Exception("Make sure the input dataset's # of rows and columns is equal to the network's input feature size and sampling size");
            }
            if (!outputCheck(output))
            {
                throw new Exception("Make sure the output dataset's # of rows and columns is equal to the network's output feature size and sampling size");
                
            }
            if (input.cols != output.cols)
            {
                throw new Exception("Make sure there are the same number of input and output samples");
            }
        }

        private void predictParameterCheck(Matrix input)
        {
            if (!inputCheck(input))
            {
                throw new Exception("Make sure the input dataset's # of rows and columns is equal to the network's input feature size and sampling size");
            }
        }

        private bool inputCheck(Matrix input)
        {
            return (input.rows == inputFeatureSize && (input.cols % samplingSize==0));
        }
        private bool outputCheck(Matrix output)
        {
            return (output.rows == outputFeatureSize && (output.cols % samplingSize==0));
        }
    }
}
