using AutoMapper;
using PatikaBookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using PatikaBookStore.Application.AuthorOperations.Queries.GetAuthors;
using PatikaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PatikaBookStore.Application.AuthorOperations.Command.CreateAuthor.CreateAuthorCommand;

namespace PatikaBookStore.Mappings.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, GetAuthorDetailModel>();
            CreateMap<CreateAuthorModel, Author>();
           
        }
    }
}
