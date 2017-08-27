using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_X_2._0.Entities
{
    public class PlacePicture
    {
        [Key]
        public int PlacePictureId { get; set; }
        //[Required]
        public int PlaceId { get; set; }     //foreign key
        public string Title { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Contents { get; set; }
        public byte[] Image { get; set; }

        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
    }
}