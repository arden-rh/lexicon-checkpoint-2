/* Product List Class */

namespace Checkpoint2
{
    public class ProductList
    {
        // Variable declarations
        public List<Product> Products { get; private set; } = new List<Product>();
        public List<Product> SortedProducts { get; private set; } = new List<Product>();
        private decimal SumOfProductPrices = 0;

        // Method to add a new product
        public void AddProduct()
        {
            while (true)
            {
                /* Start of Enter a new product loop */
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
                Console.ForegroundColor = ConsoleColor.White;

                // Get product details from user: Category, Name, Price
                string ProductCategory = InputHelper.GetValidatedStringInput("Category", out bool isQuit);

                // Check for quit command
                if (isQuit)
                {
                    break;
                }

                string ProductName = InputHelper.GetValidatedStringInput("Name", out isQuit);

                // Check for quit command
                if (isQuit)
                {
                    break;
                }

                // Get and validate product price
                decimal ProductPrice = 0;
                bool isValidPrice = false;

                do
                {
                    string ProductPriceAsString = InputHelper.GetValidatedStringInput("Price", out isQuit);
                    // Check for quit command
                    if (isQuit)
                    {
                        break;
                    }
                    isValidPrice = InputHelper.TryParseDecimal(ProductPriceAsString, out ProductPrice);
                    if (!isValidPrice)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid price entered. Please enter a valid decimal number.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                } while (!isValidPrice);

                // Check for quit command
                if (isQuit)
                {
                    break;
                }

                // Create and add the new product to the list
                string FormattedCategory = FormatStringInput(ProductCategory);
                string FormattedName = FormatStringInput(ProductName);
                Product NewProduct = new Product(FormattedCategory, FormattedName, ProductPrice);
                Products.Add(NewProduct);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------");
            }
        }

        // Method to format string input
        private string FormatStringInput(string Input)
        {
            Input = Input.ToLower();
            return char.ToUpper(Input[0]) + Input.Substring(1);
        }

        // Method to sort the list of products by price
        private static List<Product> SortListOfProducts(List<Product> ProdList)
        {
            IEnumerable<Product> ProductPriceQuery =
                from P in ProdList
                orderby P.Price
                select P;

            return ProductPriceQuery.ToList();
        }

        // Method to get the sum of all product prices
        private static decimal GetSumOfAllProducts(IEnumerable<Product> ProdList) =>
            ProdList.Sum(p => p.Price);

        // Method to display the product list
        public void GetProductList()
        {

            SortedProducts = SortListOfProducts(Products);
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Category",-25}{"Product",-20}{"Price",-10}");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Product p in SortedProducts)
            {
                Console.WriteLine($"{p.Category,-25}{p.Name,-20}{p.Price,-10}");

            }

            SumOfProductPrices = GetSumOfAllProducts(Products);
            Console.WriteLine($"\n{"",-25}{"Total amount:",-20}{SumOfProductPrices,-10}");
            Console.WriteLine("---------------------------------------------------");
        }

        // Method to search products by name
        public bool SearchProductByName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No query provided, exit search.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            // LINQ query to find matching products
            IEnumerable<Product> ProductNameQuery =
                from P in SortedProducts
                where !string.IsNullOrEmpty(P.Name) && P.Name.IndexOf(Name, StringComparison.OrdinalIgnoreCase) >= 0
                select P;

            List<Product> MatchingItems = ProductNameQuery.ToList();

            // Display results
            if (MatchingItems.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No products found matching the name: \"{Name}\"");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else
            {
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
            }

            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter \"S\" | To quit - enter: \"Q\"");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
    }
}
