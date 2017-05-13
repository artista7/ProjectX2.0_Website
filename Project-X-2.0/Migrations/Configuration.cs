namespace Project_X_2._0.Migrations
{
    using Project_X_2._0.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_X_2._0.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Project_X_2._0.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Places.AddOrUpdate(new Place { PlaceID = 1, Name = "Pawna" },
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
                                        new Place { PlaceID = 21, Name = "Latur" });
            context.Trips.AddOrUpdate(new Trip
            {
                TripID=1,
                PlaceID = 1,
                CostPerHead = 2500,
                Date = new DateTime(2017, 02, 11)
            });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}


