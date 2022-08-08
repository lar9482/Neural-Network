using System;
using Neural_Network.MatrixLibrary;

namespace Neural_Network
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            double[,] array = new[,]
            {
                {0.1, 0.2, 0.3, 0.4, 0.5},
                {1.1, 1.2, 1.3, 1.4, 1.5},
                {2.1, 2.2, 2.3, 2.4, 2.5},
                {3.1, 3.2, 3.3, 3.4, 3.5},
            };

            Matrix test = new Matrix(array);


            int newRow = 1;
            int newCol = 2;

            Matrix randTest = new Matrix(newRow, newCol);
            Matrix randTestTranspose = randTest.transpose();
            
        }
    }
}
