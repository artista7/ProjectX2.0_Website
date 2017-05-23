using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_2._0.Models
{
    public class Embarks
    {
        public int EmbarksID { get; set; }   //primary key
        public int TripID { get; set; }     //foreign key
        public string UserID { get; set; }     //foreign key
        public bool? Paid { get; set; }
        public byte? MusicFB { get; set; }
        public byte? TravellFB { get; set; }
        //public byte? FunFB { get; set; }
        public byte? FoodFB { get; set; }
        public byte? OverallFB { get; set; }

        public virtual Trip Trip { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}