using System;
using Microsoft.EntityFrameworkCore;

namespace AmazonBookStore.Models
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        public DbSet<BookInfo> BookInfos { get; set; }
    }
}
