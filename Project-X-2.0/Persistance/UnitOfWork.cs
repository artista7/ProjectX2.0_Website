using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_X_2._0.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
