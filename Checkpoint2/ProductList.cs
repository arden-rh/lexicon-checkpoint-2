
namespace Checkpoint2
{
    public class ProductList
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> SortedProducts { get; set; } = new List<Product>();
        private decimal SumOfProductPrices = 0;



        public void AddProduct(Product p)
        {
            Products.Add(p);
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
            Console.WriteLine("------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Category", -25}{"Product", -20}{"Price", -10}");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Product p in SortedProducts)
            {
                Console.WriteLine($"{p.Category, -25}{p.Name, -20}{p.Price, -10}");

            }

            SumOfProductPrices = GetSumOfAllProducts(Products);
            Console.WriteLine($"\n{"", -25}{"Total amount:", -20}{SumOfProductPrices, -10}");
            
        }

    }
}
