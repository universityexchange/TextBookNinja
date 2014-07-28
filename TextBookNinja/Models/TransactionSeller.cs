using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TextBookNinja.Models;

namespace OnlineBookWebsite.Models
{
    public class TransactionSeller
    {
        [Key, ForeignKey("Transaction")]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
