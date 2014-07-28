using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public class SellerRating
    {
        [ForeignKey("Transaction")]
        public int ID { get; set; }
        public int Rating { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(150, MinimumLength = 3)]
        public string Comment { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}