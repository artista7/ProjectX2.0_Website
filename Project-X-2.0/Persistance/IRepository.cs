using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project_X_2._0.Persistance
{
    public interface IRepository<T> where T : class
    {
        //Create
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        //Read
        T GetById(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            string includeProperties);
        IEnumerable<T> GetAll();

        //Delete
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}