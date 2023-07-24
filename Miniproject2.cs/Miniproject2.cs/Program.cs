using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;


int i = 0;
string category = null;
string name = null;
int price =0;
string iPrice = null;
bool isInt;
bool chkInt;
//string result = null;
string query = null;
int TotalAmount = 0;

List<Product> products = new List<Product>();

Console.WriteLine("To Enter a Product- follow the steps ; To Quit : Enter Q:");

while (true)
{
    Console.WriteLine("To enter a new product: Press 'enter'  | To search for a product: enter 'S' | To Quit : enter 'Q': ");
    category = Console.ReadLine();

    if (category.ToLower().Trim() == "q")
    {
        display("all");
        break;

    }
    else if (category.ToLower().Trim() == "s")
    {
        display("all");

        TotalAmount = products.Sum(product => product.Price);                        // calculates sum of all the  amounts

        Console.WriteLine(".........My products sorted.......   ");
        List<Product> sortedlist = products.OrderBy(Product => Product.Price).ToList();
        search("s");
    }
    else
    {
        //Console.WriteLine("Enter product category: ");
        addProduct();
    }

}

void addProduct()
{
        Console.WriteLine("Enter product category: ");
        category = Console.ReadLine();

        Console.WriteLine("Enter product Name: ");
        name = Console.ReadLine();

        Console.WriteLine("Enter the product price: ");
        iPrice = Console.ReadLine();

        isInt = int.TryParse(iPrice, out price);                                             // checks if input is a integer

        if (isInt)

        {
            price = Convert.ToInt32(iPrice);                                               //coverts to int32 if input is a number
        }

        else
        {
            chkInt = true;
            while (chkInt)   // As long as user enters number 
            {
                Console.WriteLine("Please enter a number : ");
                iPrice = Console.ReadLine();
                isInt = int.TryParse(iPrice, out price);
                if (isInt)
                {
                    price = Convert.ToInt32(iPrice);
                    break;
                }

            }

        }

        products.Add(new Product(category, name, price));
        Console.WriteLine("The product has been succesfully added !");

}

void search(string arg)                                 //  This Function will search for specific product entered by user
{
    arg = arg.Trim();
    if (arg.ToLower().Trim() == "s")
    {
        Console.WriteLine("Enter a product name :");
        query = Console.ReadLine();
        display(query);
    }
}

void display(string arg)
{
    Console.WriteLine(".........My products sorted.......   ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Category".PadRight(20) + "Name".PadRight(20) + "Price");
    Console.WriteLine("---------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
    List<Product> sortedlist = products.OrderBy(Product => Product.Price).ToList();

    foreach (Product prod in sortedlist)
    {   
        if (prod.Name == arg)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(prod.Category.PadRight(20) + prod.Name.PadRight(20) + prod.Price);
            Console.ForegroundColor = ConsoleColor.White;

        }
        else
        {
            Console.WriteLine(prod.Category.PadRight(20) + prod.Name.PadRight(20) + prod.Price);
        }
        
    }
    TotalAmount = products.Sum(product => product.Price);
    Console.WriteLine("                  TotalAmount:  ".PadRight(20) + "        " + TotalAmount);

}


class Product
{
    public Product(string category, string name, int price)
          {
        Category = category;
        Name = name;
        Price = price;
          }

   public string Category { get; set; }
   public string Name { get; set; }
   public int Price { get; set; }
}

