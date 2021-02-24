using System;
using System.Collections.Generic;

namespace AmazonBookStore.Models.ViewModels
{
    public class BookInfoViewModel
    {
        public IEnumerable<BookInfo> BookInfos { get; set; }

        public PageInfo PageInfo { get; set; }

    }
}
