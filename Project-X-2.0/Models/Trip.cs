using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_X_2._0.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public Nullable<int> CostPerHead { get; set; }
        public int PlaceID { get; set; }

        public virtual Place Place { get; set; }
    }
}