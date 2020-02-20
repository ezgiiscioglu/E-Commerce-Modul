using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceModul
{
    class Data
    {
        public class Product
        {
            public string ProductCode { get; set; }
            public int Price { get; set; }
            public int Stock { get; set; }
        }

        public class Order
        {
            public string ProductCode { get; set; }
            public int Quantity { get; set; }
        }

        public class Campaign
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public string ProductCode { get; set; }
            public int Duration { get; set; }
            public int PriceManipulationLimit { get; set; }
            public int TargetSalesCount { get; set; }
            public int TotalSales { get; set; }
        }

    }
}
