using northwind.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{
    public interface INorthwindUnitOfWork: IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Order> Orders { get; }
    }
}
