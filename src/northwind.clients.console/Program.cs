using Newtonsoft.Json;
using NHibernate;
using northwind.domain;
using northwind.repositories.nhibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.clients.console
{
    class Program
    {

        protected static ISessionFactory _sessionFactory { get; set; }

        static void Main(string[] args)
        {
            CommandLineArgs parameter = new CommandLineArgs();

            _sessionFactory = SessionFactory.BuildNHibernateSessionFactory();

            if (parameter.ContainsKey("list"))
                ListCatalog(parameter["list"]);
            else if (parameter.ContainsKey("create"))
                CreateEntity(parameter["create"]);
            else if (parameter.ContainsKey("delete"))
                DeleteEntity(parameter["delete"]);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid parameters... press a key to end");
            }

            Console.ReadKey();

        }

        private static void ListCatalog(string catalogName)
        {
            switch (catalogName.Trim().ToLower())
            {
                case "orders":
                    ListOrders();
                    break;
                case "customer":
                    ListCustomer();
                    break;
            }
        }

        private static void CreateEntity(string entityType)
        {
            string employeeData = File.ReadAllText("data/Employees.json");
            var employee = JsonConvert.DeserializeObject<Employee>(employeeData);
            using (var employeeRepository = new Repository<Employee>(_sessionFactory.OpenSession()))
            {
                employeeRepository.Add(employee);
                Console.WriteLine($"Employee {employee.EmployeeID} created");
            }
        }

        private static void DeleteEntity(object entityKey)
        {
            throw new NotImplementedException();
        }

        private static void ListOrders()
        {
            using (var ordersRepository = new Repository<Order>(_sessionFactory.OpenSession()))
            {
                var allOrders = ordersRepository.Get();
                foreach (var order in allOrders)
                    Console.WriteLine($"Order: {order.OrderID} for customer {order.Customer.CompanyName}");
            }
        }

        private static void ListCustomer()
        {
            using (var ordersRepository = new Repository<Customer>(_sessionFactory.OpenSession()))
            {
                var allCustomers = ordersRepository.Get();
                foreach (var customer in allCustomers)
                    Console.WriteLine($"Customer {customer.CompanyName}. Contact name {customer.ContactName}");
            }
        }
    }
}
