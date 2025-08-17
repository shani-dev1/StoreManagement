using System;
using System.Collections.Generic;
using System.Linq;
using BlApi;
using BO;

namespace BlTest
{
    class Program
    {
        static readonly IBl s_bl = BlApi.Factory.Get();

        static void Main(string[] args)
        {
            // Initialize the DAL
            // DalApi.Factory.Initialize();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Start New Order");
                Console.WriteLine("2. Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    StartNewOrder();
                }
                else if (choice == "2")
                {
                    exit = true;
                }
            }
        }

        static void StartNewOrder()
        {
            Console.WriteLine("Enter user ID or 0 for unregistered:");
            int userId;
            int.TryParse(Console.ReadLine(), out userId);

            var order = new Order { ProductsInOrder = new List<ProductInOrder>() };

            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("Enter Product ID:");
                int productId;
                int.TryParse(Console.ReadLine(), out productId);

                Console.WriteLine("Enter Quantity:");
                int quantity;
                int.TryParse(Console.ReadLine(), out quantity);

                try
                {
                    var sales = s_bl.order.AddProductToOrder(order, productId, quantity);
                    Console.WriteLine($"Product added: {string.Join(", ", sales.Select(s => s.SaleId))}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"Total price: {order.TotalPrice}");
                Console.WriteLine("Add another product? (y/n)");

                if (Console.ReadLine().ToLower() == "n")
                {
                    s_bl.order.DoOrder(order);
                    continueAdding = false;
                }
            }

            Console.WriteLine("Order completed. Start a new order? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                StartNewOrder();
            }
        }
    }
}