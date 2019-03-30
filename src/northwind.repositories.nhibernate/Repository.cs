using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories.nhibernate
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        protected internal readonly ISession _session;

        public Repository(ISession session)
        {
            this._session = session;
        }

        public T Add(T item)
        {
            this._session.Save(item);
            if (this._session.Transaction.IsActive)
                this._session.Flush();
            return item;
        }

        public T Save(T item)
        {
            this._session.Update(item);
            if (this._session.Transaction.IsActive)
                this._session.Flush();
            return item;
        }

        public void Delete(T item)
        {
            this._session.Delete(item);
            if (this._session.Transaction.IsActive)
                this._session.Flush();
        }

        public T Get(int id)
        {
            return this._session.Get<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return this._session.Query<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> query)
        {
            return this._session.Query<T>()
                .Where(query);
        }

        public void Dispose()
        {
            this._session.Dispose();
        }

    }
}
