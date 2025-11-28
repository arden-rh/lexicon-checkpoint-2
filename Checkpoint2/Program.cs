/* Checkpoint 2: Productlist */

using Checkpoint2;

// Variable declarations
ProductList ListOfProducts = new ProductList();
string UserInput;
bool SkipShowingList = false;

// Initial prompt to add the first product
ListOfProducts.AddProduct();

while (true)
{
    // If no products were added, exit the application
    if (ListOfProducts.Products.Count <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The application was closed before any products were added.");
        Console.ForegroundColor = ConsoleColor.White;
        break;
    }

    // Show the list of products unless SkipShowingList is true
    if (!SkipShowingList)
    {
        ListOfProducts.GetProductList();
    }

    // Reset SkipShowingList for next iteration
    SkipShowingList = false;

    // Show command 'menu'
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter \"S\" | To quit - enter: \"Q\"");
    Console.ForegroundColor = ConsoleColor.White;

    UserInput = Console.ReadLine();
    UserInput = UserInput.Trim();

    // Handle empty input
    if (string.IsNullOrWhiteSpace(UserInput))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please enter P, S or Q.");
        Console.ForegroundColor = ConsoleColor.White;
        SkipShowingList = true;
        continue;
    }

    /* Process user commands */
    // Check for quit command
    if (InputHelper.IsQuitCommand(UserInput))
    {
        break;
    }

    // Add a new product
    if (UserInput.Equals("P", StringComparison.OrdinalIgnoreCase))
    {
        ListOfProducts.AddProduct();
        continue;
    }

    // Search for a product
    if (UserInput.Equals("S", StringComparison.OrdinalIgnoreCase))
    {
        Console.Write("Enter a Product Name: ");
        UserInput = Console.ReadLine();
        UserInput = UserInput.Trim();
        bool Found = ListOfProducts.SearchProductByName(UserInput);

        // If the search was successful, skip showing the product list again immediately afterwards
        if (Found)
        {
            SkipShowingList = true;
        }

        continue;
    }

    // Handle unknown commands
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Unknown command. Please enter P, S or Q.");
    Console.ForegroundColor = ConsoleColor.White;
    SkipShowingList = true;
}

