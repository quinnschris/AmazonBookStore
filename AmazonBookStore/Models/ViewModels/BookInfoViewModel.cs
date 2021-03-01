using System;
using System.Collections.Generic;

namespace AmazonBookStore.Models.ViewModels
{
    //This is the model used to create the pagination at the bottom of the index page
    public class BookInfoViewModel
    {
        public IEnumerable<BookInfo> BookInfos { get; set; }

        public PageInfo PageInfo { get; set; }

        public string CurrentCategory { get; set; }

    }
}
