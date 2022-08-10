using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Activation;

namespace Neural_Network.Layers.FeedForward.Dense
{
    public class DenseLayer : BaseLayer
    {
        protected Matrix weights { get; set; }
        protected Matrix bias { get; set; }
        protected Matrix nonActivatatedContents { get; set; }

        protected activationFunction activation { get; set; }


        public DenseLayer(BaseLayer previousLayer, int layerSize, activationFunction activation)
        {
            this.previousLayer = previousLayer;
            previousLayer.nextLayer = this;

            this.LAYER_HEIGHT = layerSize;
            this.LAYER_WIDTH = previousLayer.LAYER_WIDTH;

            this.weights = new Matrix(layerSize, previousLayer.LAYER_HEIGHT);
            this.bias = new Matrix(layerSize, previousLayer.LAYER_WIDTH);
            this.activation = activation;
        }

        public void feedForward()
        {

            nonActivatatedContents = (weights.matrixMultiply(previousLayer.contents))
                                     .matrixAdd(bias);

            contents = activation.activateMatrix(nonActivatatedContents);
        }

        public void backPropagate()
        {

        }

        public void updateWeights()
        {

        }

        public void updateBias()
        {

        }
    }
}
