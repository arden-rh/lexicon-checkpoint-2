
using System.Text.RegularExpressions;

namespace Checkpoint2
{
    public class ProductList
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> SortedProducts { get; set; } = new List<Product>();
        private decimal SumOfProductPrices = 0;

        /* TODO:
         *  1. add error handling for invalid price input 
         *  2. add error handling for empty string inputs
         *  
         */


        public void AddProduct()
        {
            while (true)
            {
                /* add error handling */

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter a Category: ");
                string ProductCategory = Console.ReadLine();
                ProductCategory = ProductCategory.Trim();

                if (ProductCategory.ToUpper() == "Q")
                {
                    break;
                }

                Console.Write("Enter a Product Name: ");
                string ProductName = Console.ReadLine();
                ProductName = ProductName.Trim();

                if (ProductName.ToUpper() == "Q")
                {
                    break;
                }

                Console.Write("Enter a Price: ");
                string ProductPriceAsString = Console.ReadLine();
                ProductPriceAsString = ProductPriceAsString.Trim();

                if (ProductPriceAsString.ToUpper() == "Q")
                {
                    break;
                }

                decimal ProductPrice;
                bool isValidPrice = Decimal.TryParse(ProductPriceAsString, out ProductPrice);


                Product NewProduct = new Product(ProductCategory, ProductName, ProductPrice);
                Products.Add(NewProduct);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------");

            }
        }

        private static List<Product> SortListOfProducts(List<Product> ProdList)
        {
            IEnumerable<Product> ProductPriceQuery =
                from P in ProdList
                orderby P.Price
                select P;
            
            return ProductPriceQuery.ToList();
        }

        private static decimal GetSumOfAllProducts(IEnumerable<Product> ProdList) =>
            ProdList.Sum(p => p.Price);

        public void GetProductList()
        {

            SortedProducts = SortListOfProducts(Products);
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Category", -25}{"Product", -20}{"Price", -10}");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Product p in SortedProducts)
            {
                Console.WriteLine($"{p.Category, -25}{p.Name, -20}{p.Price, -10}");

            }

            SumOfProductPrices = GetSumOfAllProducts(Products);
            Console.WriteLine($"\n{"", -25}{"Total amount:", -20}{SumOfProductPrices, -10}");
            Console.WriteLine("---------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter \"S\" | To quit - enter: \"Q\"");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SearchProductByName(string Name)
        {
            /* add error handling for empty string */

            // If caller didn't provide a name, prompt the user
            //if (string.IsNullOrWhiteSpace(Name))
            //{
            //    Console.Write("Enter product name to search: ");
            //    Name = Console.ReadLine()?.Trim();
            //    if (string.IsNullOrWhiteSpace(Name))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Search cancelled - no input was provided.");
            //        Console.ForegroundColor = ConsoleColor.White;
            //        return;
            //    }
            //}

            // Ensure we have a sorted list to search in
            //if (SortedProducts == null || SortedProducts.Count == 0)
            //{
            //    SortedProducts = SortListOfProducts(Products);
            //}

            IEnumerable<Product> ProductNameQuery =
                from P in SortedProducts
                where !string.IsNullOrEmpty(P.Name) && P.Name.IndexOf(Name, StringComparison.OrdinalIgnoreCase) >= 0
                select P;

            List<Product> MatchingItems = ProductNameQuery.ToList();

            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Category",-25}{"Product",-20}{"Price",-10}");
            Console.ForegroundColor = ConsoleColor.White;

            // Print all products, highlighting matches
            foreach (Product p in SortedProducts)
            {
                bool IsMatch = MatchingItems.Contains(p);
                if (IsMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{p.Category,-25}{p.Name,-20}{p.Price,-10}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($"{p.Category,-25}{p.Name,-20}{p.Price,-10}");
                }
            }

            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter \"S\" | To quit - enter: \"Q\"");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
