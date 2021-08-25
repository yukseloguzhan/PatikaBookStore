using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId;
        private readonly BookStoreContext _dbcontext;

        public DeleteGenreCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(x=>x.Id == GenreId);

            if (genre == null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }

            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChanges();

        }

    }
}
