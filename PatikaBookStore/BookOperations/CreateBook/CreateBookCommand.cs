using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        private readonly BookStoreContext _dbcontext;
        public CreateBookModel _createBookModel;

        public CreateBookCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Title == _createBookModel.Title);

            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = new Book();
            book.Title = _createBookModel.Title;
            book.PublishDate = _createBookModel.PublishDate;
            book.GenreId = _createBookModel.GenreId;
            book.PageCount = _createBookModel.PageCount;

            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }


    }
}
