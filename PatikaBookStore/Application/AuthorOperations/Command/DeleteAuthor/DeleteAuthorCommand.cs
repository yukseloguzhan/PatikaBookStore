using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreContext _dbcontext;
        public int AuthorId;

        public DeleteAuthorCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var book = _dbcontext.Books.SingleOrDefault(x => x.Author.Id == AuthorId); // bak

            if (author == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            else if (book != null)
            {
                throw new InvalidOperationException("Yazara ait kitap var önce kitap silinmelidir");
            }else
            {
                _dbcontext.Authors.Remove(author);
                _dbcontext.SaveChanges();
            }

        }


    }
}
