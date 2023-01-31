using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCounter
{
    public class Price
    {
        public static double Count(List<double> prices)
        {
            double totalPrice = 0;
            foreach (double price in prices)
            {
                totalPrice += price;
            }
            return totalPrice;
        }
    }
}
