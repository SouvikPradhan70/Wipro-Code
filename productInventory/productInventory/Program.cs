using System;
namespace ProductInventory
{
    class Product
    {
        public string Name;
        public decimal Price;
        public int Quantity;
        public Product(string name,decimal price,int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;

        }
        static void Main(string[] args)
        {
            Product[] products=new Product[100];
            int productCount = 0;
            string choose = "";


            while (choose != "4")
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Products");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose a operation:");
                choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Enter product name:");
                        string p1 = Console.ReadLine();
                        Console.WriteLine("Enter product price:");
                        decimal p2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter product quantity:");
                        int p3 = Convert.ToInt32(Console.ReadLine());
                        products[productCount] = new Product(p1, p2, p3);
                        productCount++;
                        break;

                    case "2":
                        Console.WriteLine("Product:");
                        for (int i = 0; i < productCount; i++)
                        {
                            Console.WriteLine($"Product Name: {products[i].Name} ,{products[i].Name} price: {products[i].Price}, {products[i].Name} quantity: {products[i].Quantity}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter the product name you want to update:");
                        string searchName = Console.ReadLine();
                        int index = 0;
                        for (int i = 0; i < productCount; i++)
                        {
                            if (products[i] != null && products[i].Name == searchName)
                            {
                                Console.WriteLine("Product Found!!");
                                index = i;
                            }
                            else
                            {
                                Console.WriteLine("Product not found!!");
                            }
                        }
                        Console.WriteLine("Enter new product name:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Enter new product price:");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter new product quantity:");
                        int newQuantity = Convert.ToInt32(Console.ReadLine());
                        products[index].Name = newName;
                        products[index].Price = newPrice;
                        products[index].Quantity = newQuantity;
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;

                }
            }

        }
    }
}
