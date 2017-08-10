using Project_X_2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_X_2._0.Persistance
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(DbContext context) : base(context)
        {
        }
    }

    public interface ITripRepository : IRepository<Trip>
    {
    }
}
