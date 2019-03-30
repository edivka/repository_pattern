using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.repositories
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        void Rollback();
    }
}
