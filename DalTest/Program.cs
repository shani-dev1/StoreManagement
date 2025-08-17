using DalApi;
using DO;
using System.Runtime.CompilerServices;

namespace DalTest
{
    public delegate void CreateUpdateDel();

    internal class Program
    {
        private readonly static IDal s_dal = DalApi.Factory.Get;

        private static int PrintMainMenu()
        {
            int selection = 0;
            Console.WriteLine("To manage products press 1");
            Console.WriteLine("To manage customers press 2");
            Console.WriteLine("To manage sales press 3");
            Console.WriteLine("To delete all logs press 4");
            Console.WriteLine("To exit press 0");

            if (!int.TryParse(Console.ReadLine(), out selection))
                selection = -1;

            return selection;
        }

        private static int PrintSubMenu(string item)
        {
            int selection = 1;

            Console.WriteLine($"To add {item} press 1");
            Console.WriteLine($"To show {item} press 2");
            Console.WriteLine($"To show all {item} press 3");
            Console.WriteLine($"To update {item} press 4");
            Console.WriteLine($"To delete {item} press 5");
            Console.WriteLine("To go back press 0");

            if (!int.TryParse(Console.ReadLine(), out selection))
                selection = -1;

            return selection;
        }

        public static void SubMenu<T>(string item, ICrud<T> crud, CreateUpdateDel createDel, CreateUpdateDel updateDel)
        {
            int select = PrintSubMenu(item);

            while (select != 0)
            {
                switch (select)
                {
                    case 1:
                        createDel();
                        break;
                    case 2:
                        Read(crud);
                        break;
                    case 3:
                        ReadAll(crud);
                        break;
                    case 4:
                        updateDel();
                        break;
                    case 5:
                        Delete(crud);
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }

                select = PrintSubMenu(item);
            }
        }

        private static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter product code:");
                if (!int.TryParse(Console.ReadLine(), out int code))
                    code = -1;

                Console.WriteLine(s_dal.Product.Read(code));

                Product product = AskProducts(code);
                s_dal.Product.Update(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddProducts()
        {
            Product product = AskProducts();
            int code = s_dal.Product.Create(product);
            product = product with { Barcode = code };

            Console.WriteLine("Product created:");
            Console.WriteLine(product);
        }

        private static Product AskProducts(int code = 0)
        {
            Console.WriteLine("Enter product name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Category: Milky=1, Cleanliness=2, Sweets=3, Breads=4, FruitVegetables=5");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;

            Category category = select switch
            {
                1 => Category.Milky,
                2 => Category.Cleanliness,
                3 => Category.Sweets,
                4 => Category.Breads,
                5 => Category.FruitVegetables,
                _ => Category.Milky
            };

            Console.WriteLine("Enter price:");
            if (!double.TryParse(Console.ReadLine(), out double price))
                price = -1;

            Console.WriteLine("Enter quantity in stock:");
            if (!int.TryParse(Console.ReadLine(), out int quantityStock))
                quantityStock = -1;

            return new Product(code, productName, category, price, quantityStock);
        }

        private static void UpdateCustomer()
        {
            try
            {
                Console.WriteLine("Enter customer ID:");
                if (!int.TryParse(Console.ReadLine(), out int code))
                    code = -1;

                Console.WriteLine(s_dal.Customer.Read(code));

                Customer customer = AskCustomer(code);
                s_dal.Customer.Update(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddCustomer()
        {
            Customer customer = AskCustomer();
            int code = s_dal.Customer.Create(customer);
            customer = customer with { Id = code };

            Console.WriteLine("Customer created:");
            Console.WriteLine(customer);
        }

        private static Customer AskCustomer(int code = 0)
        {
            Console.WriteLine("Enter customer ID:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                id = -1;

            Console.WriteLine("Enter customer phone:");
            if (!int.TryParse(Console.ReadLine(), out int phone))
                phone = -1;

            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter customer address:");
            string address = Console.ReadLine();

            return new Customer(id, name, phone, address);
        }

        private static void UpdateSale()
        {
            try
            {
                Console.WriteLine("Enter sale code:");
                if (!int.TryParse(Console.ReadLine(), out int code))
                    code = -1;

                Console.WriteLine(s_dal.Sale.Read(code));

                Sale sale = AskSale(code);
                s_dal.Sale.Update(sale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddSale()
        {
            Sale sale = AskSale();
            int code = s_dal.Sale.Create(sale);
            sale = sale with { BarcodeSale = code };

            Console.WriteLine("Sale created:");
            Console.WriteLine(sale);
        }

        private static Sale AskSale(int code = 0)
        {
            Console.WriteLine("Enter product ID:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
                productId = -1;

            Console.WriteLine("Enter required items:");
            if (!int.TryParse(Console.ReadLine(), out int requiredItems))
                requiredItems = -1;

            Console.WriteLine("Enter total price:");
            if (!int.TryParse(Console.ReadLine(), out int totalPrice))
                totalPrice = -1;

            Console.WriteLine("Is customer in club? 0 = yes, 1 = no");
            bool isCustomerClub = Console.ReadLine() == "0";

            Console.WriteLine("How many days from today the sale begins?");
            if (!int.TryParse(Console.ReadLine(), out int day))
                day = 0;
            DateTime beginningSale = DateTime.Now.AddDays(day);

            Console.WriteLine("How many days from beginning until the sale ends?");
            if (!int.TryParse(Console.ReadLine(), out day))
                day = 0;
            DateTime endSale = beginningSale.AddDays(day);

            return new Sale(0, productId, requiredItems, totalPrice, isCustomerClub, beginningSale, endSale);
        }

        private static void Read<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("Enter code:");
                int code = int.Parse(Console.ReadLine());
                Console.WriteLine(crud.Read(code));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadAll<T>(ICrud<T> crud)
        {
            foreach (var item in crud.ReadAll())
            {
                Console.WriteLine(item);
            }
        }

        private static void Delete<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("Enter code:");
                int code = int.Parse(Console.ReadLine());
                crud.Delete(code);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to initialize data? (yes/no)");
            string initResponse = Console.ReadLine()?.ToLower();

            if (initResponse == "yes")
            {
                Initialization.Initialize();
            }

            int select = PrintMainMenu();

            try
            {
                while (select != 0)
                {
                    switch (select)
                    {
                        case 1:
                            Console.WriteLine("Product Management:");
                            SubMenu("product", s_dal.Product, AddProducts, UpdateProduct);
                            break;
                        case 2:
                            Console.WriteLine("Customer Management:");
                            SubMenu("customer", s_dal.Customer, AddCustomer, UpdateCustomer);
                            break;
                        case 3:
                            Console.WriteLine("Sale Management:");
                            SubMenu("sale", s_dal.Sale, AddSale, UpdateSale);
                            break;
                        case 4:
                            Tools.LogManager.DeleteLog();
                            break;
                        default:
                            Console.WriteLine("Wrong selection, try again");
                            break;
                    }

                    select = PrintMainMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}