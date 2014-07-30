using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public enum Condition
    {
        [Display(Name = "New")]
        New,
        [Display(Name = "As new")]
        AsNew,
        [Display(Name = "Fine")]
        Fine,
        [Display(Name = "Very good")]
        VeryGood,
        [Display(Name = "Good")]
        Good,
        [Display(Name = "Fair")]
        Fair,
        [Display(Name = "Poor")]
        Poor
    }

    public class UsersBook
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; 
        }
        [ForeignKey("Book")]
        public int BookID { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Select a correct condition.")]
        public Condition? Condition { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EditDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<BuyerBookHistory> BuyerBookHistory { get; set; }
        public virtual ICollection<SellerBookHistory> SellerBookHistory { get; set; }
    }
}