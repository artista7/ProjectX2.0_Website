using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_X_2._0.Entities
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Religion_Culture { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        
    }
}