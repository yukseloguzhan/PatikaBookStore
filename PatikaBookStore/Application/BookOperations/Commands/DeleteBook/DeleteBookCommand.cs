using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreContext _dbcontext;
        public int BookId;

        public DeleteBookCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book == null)
            {
                throw new InvalidOperationException("Bu id e sahip silinecek kitap yok!");
            }

            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
           

        }


    }
}
