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
            int[] stockPrices = { 10, 7, 5, 8, 1, 3, 9 };
            int maxProfit = GetMaxProfit(stockPrices);

            Console.WriteLine(maxProfit);
        }

        static int GetMaxProfit(int[] stockPrices)
        {
            int maxProfit = 0;
            int minStock = stockPrices[0];

            for(int i = 0; i < stockPrices.Length; i++)
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
