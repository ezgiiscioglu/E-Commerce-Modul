using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerceModul.Data;

namespace ECommerceModul
{
    class Program
    {
        static List<Product> ProductList { get; set; }
        static List<Order> OrderList { get; set; }
        static List<Campaign> CampaignList { get; set; }

        static int CurrentTime { get; set; }

        static void Main(string[] args)
        {
            ProductList = new List<Product>();
            OrderList = new List<Order>();
            CampaignList = new List<Campaign>();

            Console.Title = "Time: 00:00";

        begin:

            PrintCommandList();

        success:

            Console.Write("Write a function : ");

            var line = Console.ReadLine();
            var lineParams = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (lineParams.Length == 0)
            {
                Console.Write("Please text any command! ");
                goto begin;
            }

            var command = lineParams[0];
            var isSuccess = false;

            switch (command)
            {
                case "create_product":
                    isSuccess = CreateProdut(lineParams);
                    break;
                case "get_product_info":
                    isSuccess = GetProductInfo(lineParams);
                    break;
                case "create_order":
                    isSuccess = CreateOrder(lineParams);
                    break;
                case "create_campaign":
                    isSuccess = CreateCampaign(lineParams);
                    break;
                case "get_campaign_info":
                    isSuccess = GetCampaignInfo(lineParams);
                    break;
                case "increase_time":
                    isSuccess = IncreaseTime(lineParams);
                    break;
                default:
                    Console.Write("'{0}' isn't available! ", command);
                    break;
            }

            if (isSuccess)
                goto success;
            else
                goto begin;
        }

        static void PrintCommandList()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("  -> create_product PRODUCTCODE PRICE STOCK");
            Console.WriteLine("  -> get_product_info PRODUCTCODE");
            Console.WriteLine("  -> create_order PRODUCTCODE QUANTITY");
            Console.WriteLine("  -> create_campaign NAME PRODUCTCODE DURATION PMLIMIT TARGETSALESCOUNT");
            Console.WriteLine("  -> get_campaign_info NAME");
            Console.WriteLine("  -> increase_time HOUR");
        }

        static bool CreateProdut(string[] lineParams)
        {
                if (lineParams.Length < 4)
                {
                    Console.WriteLine("Invalid parameter lenght! ");
                    return false;
                }

                var product = ProductList.FirstOrDefault(x => x.ProductCode == lineParams[1]);
                if (product != null)
                {
                    Console.Write("'{0}' product code is already exists! ", lineParams[1]);
                    return false;
                }

                var newProduct = new Product();
                newProduct.ProductCode = lineParams[1];
                newProduct.Price = Convert.ToInt32(lineParams[2]);
                newProduct.Stock = Convert.ToInt32(lineParams[3]);
                ProductList.Add(newProduct);

                Console.WriteLine("Product created; code {0}, price {1}, stock {2}", newProduct.ProductCode, newProduct.Price, newProduct.Stock);

                return true;

        }

        static bool GetProductInfo(string[] lineParams)
        {
                if (lineParams.Length < 2)
                {
                    Console.WriteLine("Invalid parameter lenght! ");
                    return false;
                }

                var product = ProductList.FirstOrDefault(x => x.ProductCode == lineParams[1]);
                if (product == null)
                {
                    Console.Write("'{0}' product isn't exists! ", lineParams[1]);
                    return false;
                }

                Console.WriteLine("Product {0} info; price {1}, stock {2}", product.ProductCode, product.Price, product.Stock);

                return true;
        }

        static bool CreateOrder(string[] lineParams)
        {
                if (lineParams.Length < 3)
                {
                    Console.Write("Invalid parameter lenght! ");
                    return false;
                }

                var product = ProductList.FirstOrDefault(x => x.ProductCode == lineParams[1]);
                if (product == null)
                {
                    Console.Write("'{0}' product isn't exists! ", lineParams[1]);
                    return false;
                }

                product.Stock = product.Stock - Convert.ToInt32(lineParams[2]);

                var newOrder = new Order();
                newOrder.ProductCode = lineParams[1];
                newOrder.Quantity = Convert.ToInt32(lineParams[2]);
                OrderList.Add(newOrder);

                Console.WriteLine("Order created; product {0}, quantity {1}", newOrder.ProductCode, newOrder.Quantity);

                return true;
        }

        static bool CreateCampaign(string[] lineParams)
        {
                if (lineParams.Length < 6)
                {
                    Console.Write("Invalid parameter lenght! ");
                    return false;
                }

                var campaign = CampaignList.FirstOrDefault(x => x.Name == lineParams[1]);
                if (campaign != null)
                {
                    Console.Write("'{0}' campaign name is already exists! ", lineParams[1]);
                    return false;
                }

                var product = ProductList.FirstOrDefault(x => x.ProductCode == lineParams[2]);
                if (product == null)
                {
                    Console.Write("'{0}' product isn't exists! ", lineParams[2]);
                    return false;
                }

                var newCampaign = new Campaign();
                newCampaign.Name = lineParams[1];
                newCampaign.Status = "Active";
                newCampaign.ProductCode = lineParams[2];
                newCampaign.Duration = Convert.ToInt32(lineParams[3]);
                newCampaign.PriceManipulationLimit = Convert.ToInt32(lineParams[4]);
                newCampaign.TargetSalesCount = Convert.ToInt32(lineParams[5]);
                CampaignList.Add(newCampaign);

                Console.WriteLine("Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}",
                    newCampaign.Name, newCampaign.ProductCode, newCampaign.Duration, newCampaign.PriceManipulationLimit, newCampaign.TargetSalesCount);

                return true;
        }

        static bool GetCampaignInfo(string[] lineParams)
        {
                if (lineParams.Length < 2)
                {
                    Console.Write("Invalid parameter lenght! ");
                    return false;
                }

                var campaign = CampaignList.FirstOrDefault(x => x.Name == lineParams[1]);
                if (campaign == null)
                {
                    Console.Write("'{0}' campaign isn't exists! ", lineParams[1]);
                    return false;
                }

                var product = ProductList.FirstOrDefault(x => x.ProductCode == campaign.ProductCode);

                var percent = new Random().Next(campaign.PriceManipulationLimit + 1);
                var avarageItemPrice = product.Price + ((product.Price * percent) / 100);

                Console.WriteLine("Campaign {0} info; Status {1}, Target Sales {2}, Total Sales {3}, Turnover 0, Average Item Price {4}",
                    campaign.Name, campaign.Status, campaign.TargetSalesCount, campaign.TotalSales, avarageItemPrice);

                return true;
        }

        static bool IncreaseTime(string[] lineParams)
        {
                if (lineParams.Length < 2)
                {
                    Console.Write("Invalid parameter lenght! ");
                    return false;
                }

                if (CurrentTime + Convert.ToInt32(lineParams[1]) > 24)
                {
                    Console.Write("Current time can't bigger than 24 hours! ");
                    return false;
                }

                CurrentTime = CurrentTime + Convert.ToInt32(lineParams[1]);
                Console.WriteLine("Time is {0}:00", CurrentTime);

                Console.Title = "Time: " + CurrentTime.ToString("00") + ":00";

                return true;
        }

    }
}
