using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories
{
    public interface IRepository<T>: IDisposable where T : class, new()
    {
        T Get(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> query);
        T Add(T item);
        T Save(T item);
        void Delete(T item);
    }
}
