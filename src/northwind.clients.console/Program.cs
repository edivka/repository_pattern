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

        protected static INorthwindUnitOfWork _unitOfWork { get; set; }

        static void Main(string[] args)
        {
            CommandLineArgs parameter = new CommandLineArgs();

            ISessionFactory sessionFactory = SessionFactory.BuildNHibernateSessionFactory();
            _unitOfWork = new NorthwindUnitOfWork(sessionFactory.OpenSession());

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
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Commit();
            Console.WriteLine($"Employee {employee.EmployeeID} created");
        }

        private static void DeleteEntity(object entityKey)
        {
            throw new NotImplementedException();
        }

        private static void ListOrders()
        {
            foreach (var order in _unitOfWork.Orders.Get())
                Console.WriteLine($"Order: {order.OrderID} for customer {order.Customer.CompanyName}");
        }

        private static void ListCustomer()
        {
            foreach (var customer in _unitOfWork.Customers.Get())
                Console.WriteLine($"Customer {customer.CompanyName}. Contact name {customer.ContactName}");
        }
    }
}
