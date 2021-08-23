using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(

                new Book
                {
                   // Id = 1,
                    GenreId = 1, // documantary
                    PageCount = 150,
                    PublishDate = new DateTime(1985, 06, 15),
                    Title = "stendhap"
                },
                new Book
                {
                    //Id = 2,
                    GenreId = 2, // science fiction
                    PageCount = 235,
                    PublishDate = new DateTime(2001, 02, 23),
                    Title = "Dune"
                },
                new Book
                {
                    //Id = 3,
                    GenreId = 3, // science fiction
                    PageCount = 123,
                    PublishDate = new DateTime(1876, 12, 21),
                    Title = "Ateş"
                }

                );

                context.SaveChanges();
            }
        }
    }
}
