using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonBookStore.Models
{
    public class BookInfo
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        public string AuthorMiddleName { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{3})[-]([0-9]{10})$", ErrorMessage = "Not a valid ISBN Number. Format is (XXX-XXXXXXXXXX)")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public float Price { get; set; }

    }
}
