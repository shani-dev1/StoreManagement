using DO;
using DalApi;
using System;

namespace DalTest
{
    public static class Initialization
    {
        private static IDal? s_dal;

        private static void CreateProducts()
        {
            s_dal.Product.Create(new Product(0, "Milk", Category.Milky, 4.5, 50));
            s_dal.Product.Create(new Product(0, "Chocolate", Category.Milky, 3, 30));
            s_dal.Product.Create(new Product(0, "Cheese", Category.Milky, 2.5, 20));
            s_dal.Product.Create(new Product(0, "Tomato", Category.FruitVegetables, 4, 30));
            s_dal.Product.Create(new Product(0, "Cucumber", Category.FruitVegetables, 5, 30));
            s_dal.Product.Create(new Product(0, "Carrot", Category.FruitVegetables, 3, 30));
            s_dal.Product.Create(new Product(0, "Candy", Category.Sweets, 1, 100));
            s_dal.Product.Create(new Product(0, "Bamba", Category.Sweets, 4, 60));
            s_dal.Product.Create(new Product(0, "Bissli", Category.Sweets, 5.5, 70));
            s_dal.Product.Create(new Product(0, "Chips", Category.Sweets, 3.5, 70));
            s_dal.Product.Create(new Product(0, "Bread", Category.Breads, 5, 30));
            s_dal.Product.Create(new Product(0, "Roll", Category.Breads, 11, 25));
            s_dal.Product.Create(new Product(0, "Pita", Category.Breads, 14, 20));
            s_dal.Product.Create(new Product(0, "Wipes", Category.Cleanliness, 18, 10));
            s_dal.Product.Create(new Product(0, "Window Spray", Category.Cleanliness, 14, 20));
        }

        private static void CreateSales()
        {
            s_dal.Sale.Create(new Sale(0, 1000, 10, 20, false, new DateTime(2024, 10, 15), new DateTime(2025, 11, 15)));
            s_dal.Sale.Create(new Sale(0, 1100, 20, 25, true, new DateTime(2024, 10, 20), new DateTime(2025, 11, 20)));
            s_dal.Sale.Create(new Sale(0, 1200, 23, 40, false, new DateTime(2024, 11, 1), new DateTime(2025, 10, 1)));
        }

        private static void CreateCustomers()
        {
            s_dal.Customer.Create(new Customer(111, "Shani", 123456, "Jerusalem"));
            s_dal.Customer.Create(new Customer(222, "Tehila", 123456, "Tel Aviv"));
            s_dal.Customer.Create(new Customer(333, "Miri", 123456, "Haifa"));
        }

        public static void Initialize()
        {
            s_dal = DalApi.Factory.Get;
            CreateProducts();
            CreateCustomers();
            CreateSales();
        }
    }
}