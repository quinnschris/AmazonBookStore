using System;
namespace AmazonBookStore.Models.ViewModels
{
    //This is a model used for the pagination. This stores the total number of pages
    //based on the total number of items in the database, while also providing the
    //info for which page the user is viewing

    public class PageInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
