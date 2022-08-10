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

namespace Neural_Network.LearningAlgorithmBase.GradientDescent
{
    public class GradientDescent : LearningAlgorithm
    {
        public Matrix HamardProduct { get; set; }
        public GradientDescent(BaseLayer currentLayer) : base(currentLayer)
        {
            //this.HamardProduct = calculateHamardProduct(currentLayer);
            this.currentLayer = currentLayer;
        }

        /*public Matrix calculateChangeWeights(double learningRate)
        {

        }

        public Matrix calculateChangeBias(double learningRate)
        {

        }

        private Matrix calculateHamardProduct(BaseLayer currentLayer)
        {
            if (currentLayer.Equals(typeof(DenseLayer)))
            {

            }
            else
            {

            }
        }*/
    }
}
