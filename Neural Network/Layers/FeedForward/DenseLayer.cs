using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Activation;

using Neural_Network.Layers.FeedForward.Input;
using Neural_Network.Layers.FeedForward.Output;

using Neural_Network.LearningAlgorithmBase;


namespace Neural_Network.Layers.FeedForward.Dense
{
    public class DenseLayer : BaseLayer
    {
        public BaseLayer previousLayer { get; set; }
        public DenseLayer nextLayer { get; set; }


        public Matrix weights { get; set; }
        public Matrix bias { get; set; }
        public Matrix nonActivatatedContents { get; set; }

        protected activationFunction activation { get; set; }
        protected LearningAlgorithm algorithm { get; set; }

        protected double learningRate { get; set; }


        public DenseLayer(int layerSize, InputLayer previousLayer, activationFunction activation, LearningAlgorithm algorithm)
        {
            this.previousLayer = previousLayer;

            this.LAYER_HEIGHT = layerSize;
            this.LAYER_WIDTH = previousLayer.LAYER_WIDTH;

            this.weights = new Matrix(LAYER_HEIGHT, previousLayer.LAYER_HEIGHT);
            this.bias = new Matrix(LAYER_HEIGHT, previousLayer.LAYER_WIDTH);

            this.activation = activation;
            this.algorithm = algorithm;
        }

        public DenseLayer(int layerSize, DenseLayer previousLayer, activationFunction activation, LearningAlgorithm algorithm)
        {
            this.previousLayer = previousLayer;
            previousLayer.nextLayer = this;

            this.LAYER_HEIGHT = layerSize;
            this.LAYER_WIDTH = previousLayer.LAYER_WIDTH;

            this.weights = new Matrix(LAYER_HEIGHT, previousLayer.LAYER_HEIGHT);
            this.bias = new Matrix(LAYER_HEIGHT, previousLayer.LAYER_WIDTH);

            this.activation = activation;
            this.algorithm = algorithm;
        }

        public void feedForward()
        {

            nonActivatatedContents = (weights.matrixMultiply(previousLayer.contents))
                                     .matrixAdd(bias);
            

            contents = activation.activateMatrix(nonActivatatedContents);
        }

        public virtual void backPropagate()
        {
            algorithm.backPropagateDense(this);
        }

        public void updateWeights()
        {

        }

        public void updateBias()
        {

        }
    }
}
