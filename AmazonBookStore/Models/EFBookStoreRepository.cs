using System;
using System.Linq;

namespace AmazonBookStore.Models
{
    //This is the repository class where book infos are stored and loaded into a queryable
    public class EFBookStoreRepository : IBookstoreRepository
    {
        private BookstoreDbContext _context;

        public EFBookStoreRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<BookInfo> BookInfos => _context.BookInfos;
    }
}
