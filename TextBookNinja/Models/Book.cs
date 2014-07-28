using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBookWebsite.Models
{
    public enum BookType
    {
        Hardback, PaperBack, Ebook, Other
    }

    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Edition { get; set; }


        public string PublishedDate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Select a book type.")]
        public BookType? BookType { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double RetailPrice { get; set; }

        public int BookCount { get; set; }

        public string ISBN_13 { get; set; }

        public string ISBN_10 { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public string Image { get; set; }

        public double AverageRating { get; set; }

        public int RatingsCount { get; set; }

        // imageLinks
        [DataType(DataType.ImageUrl)]
        public string SmallThumbnail { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Small { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Medium { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Large { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ExtraLarge { get; set; }

        public string language { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public string EditDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public string CreateDate { get; set; }

        public string GoogleID { get; set; }
    }
}