/* Checkpoint 2: Productlist */

// ask user to enter a list of products with prices

using Checkpoint2;

ProductList ListOfProducts = new ProductList();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - follow the steps | To quit - enter: 'Q'");
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
    ListOfProducts.AddProduct(NewProduct);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The product was successfully added!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("------------------------------------------------");

}

ListOfProducts.GetProductList();