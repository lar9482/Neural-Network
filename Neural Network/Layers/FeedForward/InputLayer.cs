using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neural_Network.MatrixLibrary;

namespace Neural_Network.Layers.FeedForward.InputLayer
{
    public class InputLayer : BaseLayer
    {
        public InputLayer(int featureSize, int samplingSize)
        {
            this.LAYER_HEIGHT = featureSize;
            this.LAYER_WIDTH = samplingSize;
        }

        public void inputDataset(Matrix dataset)
        {
            if (dataset.rows != LAYER_HEIGHT || dataset.cols != LAYER_WIDTH)
            {
                throw new Exception("Feedforward.InputLayer: Make sure the dataset matches the sampling size and feature size");
            }
            else
            {
                this.contents = dataset;
            }
        }
        
    }
}
