using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using northwind.domain;

namespace northwind.repositories.nhibernate
{
    public class NorthwindUnitOfWork : INorthwindUnitOfWork
    {

        protected internal readonly ISession _session;
        protected internal readonly ITransaction _transaction;

        public NorthwindUnitOfWork(ISession session)
        {
            this._session = session;
            this._transaction = session.BeginTransaction();

            this.Customers = new Repository<Customer>(session);
            this.Employees = new Repository<Employee>(session);
            this.Orders = new Repository<Order>(session);
        }

        public IRepository<Customer> Customers { get; private set; }

        public IRepository<Employee> Employees { get; private set; }

        public IRepository<Order> Orders { get; private set; }

        public void Commit()
        {
            this._transaction.Commit();
        }

        public void Rollback()
        {
            this._transaction.Rollback();
        }

        public void Dispose()
        {
            this._transaction.Dispose();
            this._session.Dispose();
        }
    }
}
