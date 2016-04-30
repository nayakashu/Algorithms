using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] stockPrices = { 10, 5, 4,  1 };
            //int maxProfit = GetMaxProfit(stockPrices);

            //Console.WriteLine(maxProfit);

            // Product of Other Numbers

            ProductOfOtherNumbers.inputArray = new int[] {1, 2, 6, 5, 9};
            ProductOfOtherNumbers.ComputeProduct();

            foreach (int i in ProductOfOtherNumbers.outputArray)
                Console.Write(i.ToString() + " ");

            Console.ReadLine();
        }

        static int GetMaxProfit(int[] stockPrices)
        {
            if (stockPrices.Length < 2)
            {
                throw new IndexOutOfRangeException("Need to have atleast two stock values");
            }

            int maxProfit = stockPrices[1] - stockPrices[0];
            int minStock = stockPrices[0];

            for(int i = 1; i < stockPrices.Length; i++)
            {
                int profit = stockPrices[i] - minStock;

                if(profit > maxProfit)
                {
                    maxProfit = profit;
                }

                if(stockPrices[i] < minStock)
                {
                    minStock = stockPrices[i];
                }
            }

            return maxProfit;
        }
    }
}
