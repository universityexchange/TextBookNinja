using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public enum Status
    {
        Pending, Completed, InProgress, Declined, Canceled, Other, Available
    }

    public enum TransactionType
    {
        Buy, Trade, Other
    }
    public class Transaction
    {
        [Key]
        public int ID { get; set; }
        public TransactionType? TransactionType { get; set; }
        [ForeignKey("TransactionBuyer")]
        public int TransactionBuyerID { get; set; }
        [ForeignKey("TransactionSeller")]
        public int TransactionSellerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SellDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CompleteDate { get; set; }
        [ForeignKey("SellerRating")]
        public int SellerRatingID { get; set; }
        [ForeignKey("BuyerRating")]
        public int BuyerRatingID { get; set; }
        public Status? Status { get; set; }

        public virtual BuyerRating BuyerRating { get; set; }
        public virtual SellerRating SellerRating { get; set; }
        public virtual TransactionBuyer TransactionBuyer { get; set; }
        public virtual TransactionSeller TransactionSeller { get; set; }
        public virtual ICollection<BuyerBookHistory> BuyerBookHistory { get; set; }
        public virtual ICollection<SellerBookHistory> SellerBookHistory { get; set; }
    }
}