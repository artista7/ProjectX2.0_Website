using Project_X_2._0.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_X_2._0.Entities;
using System.Linq.Expressions;

namespace Project_X_2._0.FakeRepository
{
    public class FakeTripPictureRepository : ITripPictureRepository
    {
        private List<TripPicture> pics;
        public FakeTripPictureRepository()
        {
            pics = new List<TripPicture>()
            {
                new TripPicture()
                {
                    TripPictureId = 1,
                    TripId = 1,
                    //Image = new Byte[]{ 0xFFD8FFE000104A46494600010201004800480000FFE1131F4578696600004D4D002A00000008000C010000030000000107800000010100030000000104B0000001020003000000030000009E010600030000000100020000011200030000000100010000011500030000000100030000011A000500000001000000A4011B0005 };
                }
            };
        }

        public void Add(TripPicture entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TripPicture> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TripPicture> Get(Expression<Func<TripPicture, bool>> filter, Func<IQueryable<TripPicture>, IOrderedQueryable<TripPicture>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TripPicture> GetAll()
        {
            throw new NotImplementedException();
        }

        public TripPicture GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TripPicture entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TripPicture> entities)
        {
            throw new NotImplementedException();
        }
    }
}