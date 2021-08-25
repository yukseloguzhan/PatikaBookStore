using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatikaBookStore.Entities;
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

                context.Authors.AddRange(
                    new Author
                    {
                        AuthorName = "Tahsin",
                        AuthorSurname = "Yuksel",
                        BornDate = new DateTime(1985, 06, 15),
                        
                    },
                    new Author
                    {
                        AuthorName = "Kerem",
                        AuthorSurname = "Atlı",
                        BornDate = new DateTime(1923, 04, 12),
                       
                    },
                    new Author
                    {
                        AuthorName = "Okan",
                        AuthorSurname = "Kurt",
                        BornDate = new DateTime(1942, 03, 23),
                        
                    }

                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(

                new Book
                {
                    // Id = 1,
                    GenreId = 1, // documantary
                    PageCount = 150,
                    PublishDate = new DateTime(1985, 06, 15),
                    Title = "stendhap",
                    AuthorId = 2
                },
                new Book
                {
                    //Id = 2,
                    GenreId = 2, // science fiction
                    PageCount = 235,
                    PublishDate = new DateTime(2001, 02, 23),
                    Title = "Dune",
                    AuthorId = 1
                },
                new Book
                {
                    //Id = 3,
                    GenreId = 3, // science fiction
                    PageCount = 123,
                    PublishDate = new DateTime(1876, 12, 21),
                    Title = "Ateş",
                    AuthorId = 3
                }

                );

                context.SaveChanges();
            }
        }
    }
}
