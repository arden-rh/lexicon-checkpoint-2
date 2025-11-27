
namespace Checkpoint2
{
    public class ProductList
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> SortedProducts { get; set; } = new List<Product>();
        private decimal SumOfProductPrices = 0;



        public void AddProduct()
        {
            while (true)
            {
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

    }
}
