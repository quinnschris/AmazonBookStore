using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<BookInfo> BookInfos { get; }
    }
}
