using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Layers;

namespace SerializationTools.Layers.FeedForward.Dense
{
    internal class DenseLayerObject : BaseLayer
    {
        public Matrix weights { get; set; }
        public Matrix bias { get; set; }
        public Matrix nonActivatatedContents { get; set; }
        public string activation { get; set; }
        public string learningAlgorithm { get; set; }

        public double learningRate { get; set; }

        
    }
}
