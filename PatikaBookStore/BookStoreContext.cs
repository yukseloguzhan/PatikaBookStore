using Microsoft.EntityFrameworkCore;
using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Books { set; get; }
        public DbSet<Genre>  Genres { set; get; }
        public DbSet<Author>  Authors { set; get; }



    }
}
