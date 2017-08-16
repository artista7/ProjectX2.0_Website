using Project_X_2._0.Entities;
using Project_X_2._0.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Project_X_2._0.FakeRepository
{
    public class FakeTripRepository : ITripRepository
    {
        private List<Trip> _trips;
        public FakeTripRepository()
        {
            _trips = new List<Trip>()
            { new Trip
                    {
                        TripID = 1,
                        PlaceID = 1,
                        CostPerHead = 2500,
                        Date = new DateTime(2017, 02, 11)
                    },
            new Trip
                    {
                        TripID = 2,
                        PlaceID = 1,
                        CostPerHead = 1600,
                        Date = new DateTime(2017, 05, 11)
                    }
            };
        }

        public void Add(Trip entity)
        {
            _trips.Add(entity);
        }

        public void AddRange(IEnumerable<Trip> entities)
        {
            _trips.AddRange(entities);
        }

        public IEnumerable<Trip> Get(Expression<Func<Trip, bool>> filter, Func<IQueryable<Trip>, IOrderedQueryable<Trip>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> GetAll()
        {
            return _trips;
        }

        public Trip GetById(int id)
        {
            return _trips.SingleOrDefault(x => x.TripID == id);
        }

        public void Remove(int id)
        {
            var trip = _trips.SingleOrDefault(x => x.TripID == id);
            _trips.Remove(trip);
        }

        public void Remove(Trip entity)
        {
            _trips.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Trip> entities)
        {
            throw new NotImplementedException();
        }
    }
}
