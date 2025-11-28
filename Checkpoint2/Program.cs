/* Checkpoint 2: Productlist */

// ask user to enter a list of products with prices

using Checkpoint2;

ProductList ListOfProducts = new ProductList();
string UserInput;

ListOfProducts.AddProduct();

while (true)
{

    ListOfProducts.GetProductList();

    UserInput = Console.ReadLine();


    if (UserInput.ToUpper() == "Q")
    {
        break;
    }

    if (UserInput.ToUpper() == "P")
    {
        ListOfProducts.AddProduct();
        continue;
    }

    if (UserInput.ToUpper() == "S")
    {
        Console.Write("Enter a Product Name: ");
        UserInput = Console.ReadLine();
        ListOfProducts.SearchProductByName(UserInput);
        continue;

    }
}

