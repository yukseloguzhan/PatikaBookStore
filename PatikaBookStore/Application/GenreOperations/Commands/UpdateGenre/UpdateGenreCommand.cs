using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId;
        private readonly BookStoreContext _dbcontext;
        public UpdateGenreModel _updateGenreModel;

        public UpdateGenreCommand(BookStoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(x => x.Id == GenreId);
           
            if (genre == null)
            {
                throw new InvalidOperationException("Güncellenecek kitap türü bulunamadı");
            }

            if (_dbcontext.Genres.Any(x=>x.Name.ToLower() == _updateGenreModel.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Böyle bir kitap türü zaten mevcut");
            }

            genre.Name = string.IsNullOrEmpty(_updateGenreModel.Name.Trim())  ? genre.Name : _updateGenreModel.Name;
            genre.isActive = _updateGenreModel.isActive;
            _dbcontext.SaveChanges();
        }


    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; } = true;

    }

}
