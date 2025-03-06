// See https://aka.ms/new-console-template for more information
using ComputersMannager;
using System.Reflection.Metadata;

string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Computers;Integrated Security=True;Encrypt=False";
DataAccess dataAccess = new DataAccess();
Console.WriteLine("in order to insert a category press c,\nin order to insert product press p,\npress other key to finish:");
string ans = Console.ReadLine();
while (ans.Equals("c")|| ans.Equals("p"))
    {
        if (ans.Equals("c"))
        {
            dataAccess.InsertCategory(connectionString);
            Console.WriteLine("in order to insert a category press c,\nin order to insert product press p,\npress other key to finish:");
            ans = Console.ReadLine();
        }
        else
        {
        dataAccess.InsertProduct(connectionString);
        Console.WriteLine("in order to insert a category press c,\nin order to insert product press p,\npress other key to finish:");
        ans = Console.ReadLine();
        }

    }
    Console.WriteLine("Ctegories");
    dataAccess.readDataCategories(connectionString);
    Console.WriteLine("Products");
    dataAccess.readDataProducts(connectionString);
