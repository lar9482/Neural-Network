using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Layers.FeedForward.Dense;
using Neural_Network.Error;
using Neural_Network.Activation;
using Neural_Network.LearningAlgorithmBase;

namespace Neural_Network.Layers.FeedForward.Output
{
    public class OutputLayer : DenseLayer
    {
        public Matrix truthMatrix { get; set; }
        
        public errorFunction errorFunction { get; set; }


        public OutputLayer(Matrix truthMatrix, double learningRate, DenseLayer previousLayer, activationFunction activation,
                           errorFunction error, LearningAlgorithm algorithm)
            : base(truthMatrix.rows, learningRate, previousLayer, activation, algorithm)
        {
            this.errorFunction = error;
            this.truthMatrix = truthMatrix;
        }

        public override void backPropagate()
        {
            algorithm.backPropagateOutput(this);
        }
        
    }
}


