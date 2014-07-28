using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public class BuyerBookHistory
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Transaction")]
        public int TransactionID { get; set; }
        [ForeignKey("UsersBook")]
        public int UsersBookID { get; set; }

        public virtual UsersBook UsersBook { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}