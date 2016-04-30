using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeProblem
{
    class ProductOfOtherNumbers
    {
        public static int[] inputArray = new int[5];

        public static int[] outputArray = new int[5];

        public static void ComputeProduct() 
        {
            int leftMultiplier = 1, rightMultiplier = 1;
            for(int i = 0, j = inputArray.Length - 1; i < inputArray.Length; i++, j--) 
            {
                if (i > 0)
                {
                    leftMultiplier *= inputArray[i - 1];
                }
                if (j < inputArray.Length - 1)
                {
                    rightMultiplier *= inputArray[j + 1];
                }

                if (outputArray[i] == 0)
                    outputArray[i] = 1;
                if (outputArray[j] == 0)
                    outputArray[j] = 1;

                outputArray[i] *= leftMultiplier;
                outputArray[j] *= rightMultiplier;
            }

        }
    }
}
