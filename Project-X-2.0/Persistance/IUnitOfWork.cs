using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X_2._0.Persistance
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void Dispose();
    }
}
