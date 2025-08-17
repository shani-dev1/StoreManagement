namespace Dal
{
    using DO;
    using DalApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Tools;

    internal class CustomerImplementation : Icustomer
    {
        public int Create(Customer item)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"Insert customer with ID: {item.Id}");

            bool exists = DataSource.customers.Any(x => x.Id == item.Id);

            if (exists)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    "This customer already exists with this ID");
                throw new DalIdExistException("This code already exists");
            }

            DataSource.customers.Add(item);
            return item.Id;
        }

        public Customer? Read(int id)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"Read customer with ID: {id}");

            var customer = DataSource.customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    $"Customer not found with ID: {id}");
                throw new DalIdNotFoundException("This code does not exist");
            }

            return customer;
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                "Read customer by filter");

            var customer = DataSource.customers.FirstOrDefault(x => filter(x));

            if (customer == null)
            {
                LogManager.WriteToLog(
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name,
                    "Customer not found");
                throw new DalIdNotFoundException("This customer does not exist");
            }

            return customer;
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                "Read all customers");

            if (filter == null)
            {
                return new List<Customer>(DataSource.customers);
            }

            return DataSource.customers.Where(x => filter(x)).ToList();
        }

        public void Update(Customer item)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"Update customer with ID: {item.Id}");

            Delete(item.Id);
            DataSource.customers.Add(item);
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,
                $"Delete customer with ID: {id}");

            var customer = Read(id);
            DataSource.customers.Remove(customer);
        }
    }
}
