﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.LearningAlgorithmBase;

namespace Neural_Network.Layers
{
    public abstract class BaseLayer
    {
        public Matrix contents { get; set; }
        public BaseLayer previousLayer { get; set; }
        public BaseLayer nextLayer { get; set; }


        public int LAYER_HEIGHT { get; set; }
        public int LAYER_WIDTH { get; set; }

        public LearningAlgorithm algorithm { get; set; }

    }
}
