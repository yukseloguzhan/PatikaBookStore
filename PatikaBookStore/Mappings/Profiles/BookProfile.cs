using AutoMapper;
using PatikaBookStore.BookOperations.GetBooks;
using PatikaBookStore.BookOperations.GetByIdBook;
using PatikaBookStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PatikaBookStore.BookOperations.CreateBook.CreateBookCommand;

namespace PatikaBookStore.Mappings.Profiles
{
    public class BookProfile : Profile
    {

        public BookProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksDetailViewModel>().ForMember(x => x.Genre, y => y.MapFrom(c => ((GenreEnum)c.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(x => x.Genre, y => y.MapFrom(c => ((GenreEnum)c.GenreId).ToString()));
        }



    }
}
