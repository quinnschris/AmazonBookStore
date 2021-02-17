using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonBookStore.Models
{
    public class BookInfo
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        [RegularExpression(@"^([0-9]{3})[-]([0-9]{10})$", ErrorMessage = "Not a valid ISBN Number. Format is (XXX-XXXXXXXXXX)")]
        public string ISBN { get; set; }

        public string Category { get; set; }

        public float Price { get; set; }

    }
}
