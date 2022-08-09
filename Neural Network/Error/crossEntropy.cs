﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network.Error
{
    public class crossEntropy : errorFunction
    {
        public override double error(double expected, double actual)
        {
            return -(expected*Math.Log(actual) + (1-expected)*Math.Log(1-actual));
        }

        public override double errorDerivative(double expected, double actual)
        {
            return -((expected / actual) + (1-expected)/(1-actual) );
        }
    }
}
