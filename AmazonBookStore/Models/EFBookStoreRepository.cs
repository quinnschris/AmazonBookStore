using System;
using System.Linq;

namespace AmazonBookStore.Models
{
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
