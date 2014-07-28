using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Url]
        public string SocialLinkedin { get; set; }

        [Url]
        public string SocialFacebook { get; set; }

        [Url]
        public string SocialTwitter { get; set; }

        public string AuthorImage { get; set; }
    }
}