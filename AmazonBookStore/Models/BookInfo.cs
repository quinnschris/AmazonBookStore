using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonBookStore.Models
{
    public class BookInfo
    {

        //The id number that increments
        [Key]
        public int Id { get; set; }

        //Title of the book
        [Required]
        public string Title { get; set; }

        //Authors first and last name required, last name is optional
        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        public string AuthorMiddleName { get; set; }

        //Publisher of the book
        [Required]
        public string Publisher { get; set; }

        //ISBN of the book that must be in specified format
        [Required]
        [RegularExpression(@"^([0-9]{3})[-]([0-9]{10})$", ErrorMessage = "Not a valid ISBN Number. Format is (XXX-XXXXXXXXXX)")]
        public string ISBN { get; set; }

        //Classification of the book
        [Required]
        public string Classification { get; set; }

        //Category of the book
        [Required]
        public string Category { get; set; }

        //Price of the book
        [Required]
        public float Price { get; set; }

    }
}
