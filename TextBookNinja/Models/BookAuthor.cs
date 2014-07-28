using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public class BookAuthor
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}