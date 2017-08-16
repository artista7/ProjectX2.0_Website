using Project_X_2._0.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_X_2._0.Entities;
using System.Linq.Expressions;

namespace Project_X_2._0.FakeRepository
{
    public class FakeUserTripDetailsRepository : IUserTripDetailsRepository
    {
        private List<UserTripDetail> _userTripDetails;

        public FakeUserTripDetailsRepository()
        {
            _userTripDetails = new List<UserTripDetail>()
            {
                new UserTripDetail()
                {
                    UserTripDetailID = 1,
                    TripID = 1,
                    FoodFB = 4,
                    TravellFB = 3,
                    MusicFB = 4,
                    UserID = "2c176303-abfc-4834-baa3-95f15aa4a031",
                },
                new UserTripDetail()
                {
                    UserTripDetailID = 2,
                    TripID = 2,
                    FoodFB = 4,
                    TravellFB = 3,
                    MusicFB = 4,
                    UserID = "2c176303-abfc-4834-baa3-95f15aa4a031",
                },
            };
        }

        public void Add(UserTripDetail entity)
        {
            _userTripDetails.Add(entity);
        }

        public void AddRange(IEnumerable<UserTripDetail> entities)
        {
            _userTripDetails.AddRange(entities);
        }

        public UserTripDetail GetById(int id)
        {
            return _userTripDetails.SingleOrDefault(x => x.UserTripDetailID == id);
        }

        public IEnumerable<UserTripDetail> Get(Expression<Func<UserTripDetail, bool>> filter, Func<IQueryable<UserTripDetail>, IOrderedQueryable<UserTripDetail>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTripDetail> GetAll()
        {
            return _userTripDetails;
        }

        public void Remove(int id)
        {
            var userTripDetail = _userTripDetails.SingleOrDefault(x => x.UserTripDetailID == id);
            _userTripDetails.Remove(userTripDetail);
        }

        public void Remove(UserTripDetail entity)
        {
            _userTripDetails.Remove(entity);
        }

        public void RemoveRange(IEnumerable<UserTripDetail> entities)
        {
            throw new NotImplementedException();
        }
    }
}
