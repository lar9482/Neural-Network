using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;

namespace Neural_Network.LearningAlgorithm
{
    public abstract class LearningAlgorithm
    {
        public Matrix changeWeights { get; set; }
        public Matrix changeBias { get; set; }
    }
}
