using Project_X_2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_X_2._0.Persistance
{
    public class EmbarksRepository : Repository<Embarks>, IEmbarksRepository
    {
        public EmbarksRepository(DbContext context) : base(context)
        {
        }
    }

    internal interface IEmbarksRepository : IRepository<Embarks>
    {
    }
}
