using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;
        public int GenreId;

        public GetGenreDetailQuery(BookStoreContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(x => x.Id == GenreId && x.isActive);

            if (genre == null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }

            GenreDetailViewModel obj= _mapper.Map<GenreDetailViewModel>(genre);
            return obj;
        }

    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

