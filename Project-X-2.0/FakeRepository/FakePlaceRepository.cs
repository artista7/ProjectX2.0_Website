using Project_X_2._0.Entities;
using Project_X_2._0.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Project_X_2._0.FakeRepository
{
    public class FakePlaceRepository : IPlaceRepository
    {
        private List<Place> _places;
        public FakePlaceRepository()
        {
            _places = new List<Place>()
            {
                                        new Place { PlaceID = 1, Name = "Pawna" },
                                        new Place { PlaceID = 2, Name = "Jutogh" },
                                        new Place { PlaceID = 3, Name = "Andaman Nicobar" },
                                        new Place { PlaceID = 4, Name = "Malaysia" },
                                        new Place { PlaceID = 5, Name = "Nepal" },
                                        new Place { PlaceID = 6, Name = "Coorg" },
                                        new Place { PlaceID = 7, Name = "Gangtok" },
                                        new Place { PlaceID = 8, Name = "Lakshadweep" },
                                        new Place { PlaceID = 9, Name = "Goa" },
                                        new Place { PlaceID = 10, Name = "Gokarna" },
                                        new Place { PlaceID = 11, Name = "Kanyakumari" },
                                        new Place { PlaceID = 12, Name = "Kasol" },
                                        new Place { PlaceID = 13, Name = "Hrishikesh" },
                                        new Place { PlaceID = 14, Name = "Gangotri" },
                                        new Place { PlaceID = 15, Name = "Hampi" },
                                        new Place { PlaceID = 16, Name = "Mumbai" },
                                        new Place { PlaceID = 17, Name = "Jaipur" },
                                        new Place { PlaceID = 18, Name = "Agra" },
                                        new Place { PlaceID = 19, Name = "McLeodganj" },
                                        new Place { PlaceID = 20, Name = "Ajmer" },
                                        new Place { PlaceID = 21, Name = "Latur" },
                                        new Place { PlaceID = 22, Name = "Malvan" }
            };
        }

        public void Add(Place entity)
        {
            _places.Add(entity);
        }

        public void AddRange(IEnumerable<Place> entities)
        {
            _places.AddRange(entities);
        }

        public IEnumerable<Place> Get(Expression<Func<Place, bool>> filter, Func<IQueryable<Place>, IOrderedQueryable<Place>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetAll()
        {
            return _places;
        }

        public Place GetById(int id)
        {
            return _places.SingleOrDefault(x => x.PlaceID == id);
        }

        public void Remove(int id)
        {
            var place = _places.SingleOrDefault(x => x.PlaceID == id);
            _places.Remove(place);
        }

        public void Remove(Place entity)
        {
            _places.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Place> entities)
        {
            throw new NotImplementedException();
        }
    }
}