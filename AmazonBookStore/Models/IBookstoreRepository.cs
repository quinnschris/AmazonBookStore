using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    //This is where the queryable of the database is stored

    public interface IBookstoreRepository
    {
        IQueryable<BookInfo> BookInfos { get; }
    }
}
