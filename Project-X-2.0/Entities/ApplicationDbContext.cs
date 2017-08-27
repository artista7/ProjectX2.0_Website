using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace Project_X_2._0.Entities
{
    public interface IApplicationDbContext : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<UserTripDetail> UserTripDetails { get; set; }
        public DbSet<TripPicture> TripPictures { get; set; }
        public DbSet<PlacePicture> PlacePictures { get; set; }

        IQueryable<T> IApplicationDbContext.Query<T>()
        {
            return Set<T>();
        }
    }
}