using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonBookStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.BookInfos.Any())
            {
                //This is all the seed data provide by professor Hilton, created into
                //invidual objects of the class "BookInfo". Pretty neat

                context.BookInfos.AddRange(
                    new BookInfo
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95F
                    },

                    new BookInfo
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58F
                    },

                    new BookInfo
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54F
                    },

                    new BookInfo
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleName = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61F
                    },

                    new BookInfo
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33F
                    },

                    new BookInfo
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95F
                    },

                    new BookInfo
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99F
                    },

                    new BookInfo
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66F
                    },

                    new BookInfo
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16F
                    },

                    new BookInfo
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03F
                    },

                    new BookInfo
                    {
                        Title = "The Way of Kings",
                        AuthorFirstName = "Brandon",
                        AuthorLastName = "Sanderson",
                        Publisher = "Tor",
                        ISBN = "978-0765326355",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 17.99F
                    },

                    new BookInfo
                    {
                        Title = "Born a Crime",
                        AuthorFirstName = "Trevor",
                        AuthorLastName = "Noah",
                        Publisher = "One World",
                        ISBN = "978-0399588174",
                        Classification = "Non-Fiction",
                        Category = "Auto-biography",
                        Price = 14.50F
                    },

                    new BookInfo
                    {
                        Title = "Coddling of the American Mind",
                        AuthorFirstName = "Greg",
                        AuthorLastName = "Lukianoff",
                        Publisher = "Penguin Books",
                        ISBN = "978-0735224896",
                        Classification = "Non-Fiction",
                        Category = "Psychology",
                        Price = 9.99F
                    }

                    ) ;

                context.SaveChanges();

                
            }
        }
    }
}
