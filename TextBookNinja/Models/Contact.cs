using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public int PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [DataType(DataType.PostalCode)]
        [Required]
        public int Zip { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}