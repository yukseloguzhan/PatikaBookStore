using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly BookStoreContext _dbcontext;
        public CreateGenreModel _createGenreModel;

        public CreateGenreCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(x=>x.Name == _createGenreModel.Name);
            if (genre != null)
            {
                throw new InvalidOperationException("Kitap türü zaten var");
            }

            genre = new Genre();
            genre.Name = _createGenreModel.Name;
            _dbcontext.Genres.Add(genre);
            _dbcontext.SaveChanges();

        }


    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }


}
