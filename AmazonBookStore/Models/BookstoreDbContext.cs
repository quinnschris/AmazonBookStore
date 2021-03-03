using System;
using Microsoft.EntityFrameworkCore;

namespace AmazonBookStore.Models
{
    //This is the context class that is used for generating the database

    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        public DbSet<BookInfo> BookInfos { get; set; }
    }
}
