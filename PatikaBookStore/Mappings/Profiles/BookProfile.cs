using AutoMapper;
using PatikaBookStore.Application.BookOperations.Queries.GetBooks;
using PatikaBookStore.Application.BookOperations.Queries.GetByIdBook;
using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PatikaBookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;


namespace PatikaBookStore.Mappings.Profiles
{
    public class BookProfile : Profile
    {

        public BookProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksDetailViewModel>().ForMember(x => x.Genre, y => y.MapFrom(c => c.Genre.Name))
                                                   .ForMember(x=>x.Author,y => y.MapFrom(c=>c.Author.AuthorName + c.Author.AuthorSurname));
            CreateMap<Book, BooksViewModel>().ForMember(x => x.Genre, y => y.MapFrom(c => c.Genre.Name))
                                             .ForMember(x => x.Author, y => y.MapFrom(c => c.Author.AuthorName + c.Author.AuthorSurname));
        }



    }
}
