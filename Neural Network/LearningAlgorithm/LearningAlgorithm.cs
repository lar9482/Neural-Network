using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Layers;

namespace Neural_Network.LearningAlgorithmBase
{
    public abstract class LearningAlgorithm
    {
        public BaseLayer currentLayer { get; set; }
        
        public LearningAlgorithm(BaseLayer currentLayer)
        {
            this.currentLayer = currentLayer;
        }
    }
}
