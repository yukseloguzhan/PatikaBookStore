using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreContext _dbcontext;
        public UpdateBookModel _updateBookModel;
        public int BookId;

        public UpdateBookCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book == null)
            {
                throw new InvalidOperationException("Kayıtlı böyle bir data yok!");
            }

            book.GenreId = _updateBookModel.GenreId != default ? _updateBookModel.GenreId : book.GenreId;
            book.Title = _updateBookModel.Title != default ? _updateBookModel.Title : book.Title;

            _dbcontext.SaveChanges();
            

        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }

        }

    }
}
