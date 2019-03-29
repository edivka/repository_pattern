using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.clients.console
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineArgs parameter = new CommandLineArgs();
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
                Console.ReadKey();
            }
        }

        private static void ListCatalog(string catalogName)
        {
            throw new NotImplementedException();
        }

        private static void CreateEntity(string entityType)
        {
            throw new NotImplementedException();
        }

        private static void DeleteEntity(object entityKey)
        {
            throw new NotImplementedException();
        }

    }
}
