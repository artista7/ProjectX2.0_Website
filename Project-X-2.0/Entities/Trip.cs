using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_X_2._0.Entities
{
    public class Trip
    {
        public int TripID { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public Nullable<int> CostPerHead { get; set; }
        public int PlaceID { get; set; }        //foreign key
        public int TripPictureId { get; set; }        //foreign key

        [ForeignKey("PlaceID")]
        public virtual Place Place { get; set; }
        [ForeignKey("TripPictureId")]
        public virtual IEnumerable<TripPicture> TripPictures { get; set; }
    }
}