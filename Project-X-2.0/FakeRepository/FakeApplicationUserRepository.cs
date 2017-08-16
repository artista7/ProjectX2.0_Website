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
    public class FakeApplicationUserRepository : IApplicationUserRepository
    {
        private List<ApplicationUser> _applicationUsers;

        public FakeApplicationUserRepository()
        {
            _applicationUsers = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "2c176303-abfc-4834-baa3-95f15aa4a031",
                    Email = "indian6ws@yahoo.in",
                    UserName = "indian6ws@yahoo.in",
                    PhoneNumber = "9582819710",
                },

                new ApplicationUser()
                {
                    Id = "AIRklKIfkZFPQIsRiwHniU9Z8kcQKDLdPiGydDLZP9fIktGwe8CopNPuGAHl3P8ksw==",
                    Email = "shubham1.6180@gmail.com",
                    UserName = "Shanty",
                    PhoneNumber = "9582819710",
                },
            };
        }

        public void Add(ApplicationUser entity)
        {
            _applicationUsers.Add(entity);
        }

        public void AddRange(IEnumerable<ApplicationUser> entities)
        {
            _applicationUsers.AddRange(entities);
        }

        public IEnumerable<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> filter, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _applicationUsers;
        }

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }
    }
}
