using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreContext _dbcontext;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _dbcontext.Genres.Where(x=>x.isActive == true).OrderBy(x=>x.Id);
            List<GenresViewModel> list = _mapper.Map<List<GenresViewModel>>(genres);
            return list;
        }

    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
