using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neural_Network.MatrixLibrary;
using Neural_Network.Activation;
using Neural_Network.Error;

using Neural_Network.Layers;
using Neural_Network.Layers.FeedForward.Dense;
using Neural_Network.Layers.FeedForward.Output;

namespace Neural_Network.LearningAlgorithmBase.GradientDescent
{
    public class GradientDescent : LearningAlgorithm
    {

        public GradientDescent()
        {

        }


        public override void backPropagateDense(DenseLayer layer)
        {

        }

        public override void backPropagateOutput(OutputLayer layer)
        {

        }

        public override Matrix calculateChangeWeights()
        {
            return new Matrix(0, 0);
        }

        public override Matrix calculateChangeBias()
        {
            return new Matrix(0, 0);
        }
    }
}
