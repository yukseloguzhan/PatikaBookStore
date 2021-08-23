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

        public UpdateBookCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle(int id)
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Id == id);

            if (book == null)
            {
                throw new InvalidOperationException("Kayıtlı böyle bir data yok!"+book.Id);
            }

            book.GenreId = _updateBookModel.GenreId != default ? _updateBookModel.GenreId : book.GenreId;
            book.PageCount = _updateBookModel.PageCount != default ? _updateBookModel.PageCount : book.PageCount;
            book.PublishDate = _updateBookModel.PublishDate != default ? _updateBookModel.PublishDate : book.PublishDate;
            book.Title = _updateBookModel.Title != default ? _updateBookModel.Title : book.Title;

            _dbcontext.SaveChanges();
            

        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }

    }
}
