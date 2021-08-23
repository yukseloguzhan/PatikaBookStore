using PatikaBookStore.BookOperations.GetBooks;
using PatikaBookStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.GetByIdBook
{
    public class GetByIdBookQuery
    {
        private readonly BookStoreContext _dbcontext;

        public GetByIdBookQuery(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public BooksViewModel Handle(int id)
        {
            var book = _dbcontext.Books.Where(x => x.Id == id).SingleOrDefault();

            if (book == null)
            {
                throw new InvalidOperationException("Bu id'e sahip kitap yok!");
            }


            var bookView = new BooksViewModel
            {
                PageCount = book.PageCount,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                Title = book.Title
            };

            return bookView;


        }

    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}
