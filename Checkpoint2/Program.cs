/* Checkpoint 2: Productlist */

// ask user to enter a list of products with prices

using Checkpoint2;

ProductList ListOfProducts = new ProductList();
string UserInput;

while (true)
{
    ListOfProducts.AddProduct();

    ListOfProducts.GetProductList();

    UserInput = Console.ReadLine();


    if (UserInput.ToUpper() == "Q")
    {
        break;
    }

    if (UserInput.ToUpper() == "P")
    {
        continue;
    }

    if (UserInput.ToUpper() == "S")
    {
        Console.WriteLine("nu skrev vi s");

    }
}

