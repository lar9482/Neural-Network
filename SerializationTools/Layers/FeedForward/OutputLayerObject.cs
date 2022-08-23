using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SerializationTools.Layers.FeedForward.Dense;

using Neural_Network.MatrixLibrary;

namespace SerializationTools.Layers.FeedForward.Output
{
    internal class OutputLayerObject : DenseLayerObject
    {
        public Matrix truthMatrix { get; set; }
        public string errorFunction { get; set; }
    }
}
