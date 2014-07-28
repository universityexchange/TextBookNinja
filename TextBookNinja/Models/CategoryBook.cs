using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public class CategoryBook
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}