using Project_X_2._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_X_2._0.Persistance
{
    public class TripPictureRepository : Repository<TripPicture>, ITripPictureRepository
    {
        public TripPictureRepository(DbContext context) : base(context)
        {
        }
    }

    public interface ITripPictureRepository : IRepository<TripPicture>
    {
    }
}
