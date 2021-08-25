using AutoMapper;
using PatikaBookStore.Application.GenreOperations.Queries.GetGenreDetail;
using PatikaBookStore.Application.GenreOperations.Queries.GetGenres;
using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaBookStore.Mappings.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}
