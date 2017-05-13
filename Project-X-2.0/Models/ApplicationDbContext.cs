using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Project_X_2._0.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
    }
}